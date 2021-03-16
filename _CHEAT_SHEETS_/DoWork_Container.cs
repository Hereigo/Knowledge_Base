using GrpcPushsender;
using Microsoft.Extensions.Hosting;
using PushSenderWorker.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PushSenderWorker.Helper;

namespace PushSenderWorker
{
	public class Container : ContainerBase, IHostedService, IDisposable
	{
		private Timer _timer;
		private CampaignWorkerFactory _campaignWorkerFactory;
		private ILogger<Container> _logger;
		private IBridgeServicesProvider _bridge;
		private ISystemDate _systemDate;
		private DateTime UpdatedAt;

		private readonly CampaignWorkerList<ICampaignWorker> _campaignsWorkers;

		public Container(CampaignTypeEnum type, IBridgeServicesProvider bridge,
			CampaignWorkerFactory campaignWorkerFactory,
			ISystemDate systemDate,
			ILogger<Container> logger):base(type)
		{
			_campaignWorkerFactory = campaignWorkerFactory;
			_logger = logger;
			_bridge = bridge;
			_systemDate = systemDate;

			_campaignsWorkers = new CampaignWorkerList<ICampaignWorker>(_campaignWorkerFactory);
		}

		public void Dispose()
		{
			foreach (var item in _campaignsWorkers)
			{
				item.StopAsync().GetAwaiter().GetResult();
			}

			_bridge.Stop();

			_timer?.Dispose();
		}

		private void DoWork(object state)
		{
			_timer.Change(Timeout.Infinite, Timeout.Infinite);

			try
			{
				var allCampaigns = _bridge.CampaignPushSender.GetByTypeAsync(Type, 0, 10000, UpdatedAt).GetAwaiter().GetResult();

				UpdatedAt = _systemDate.UtcNow;

				foreach (var item in allCampaigns)
				{
					_campaignsWorkers.TryAddOrUpdate(new CampaignDataBase(item, LokalizeHelper.GetLocalizeData()));
				}

				foreach (var worker in _campaignsWorkers)
				{
					worker.StartAsync();
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed in DoWork");
			}

			_timer.Change(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			_timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

			return Task.CompletedTask;
		}

		public async Task StopAsync(CancellationToken cancellationToken)
		{
			foreach (var worker in _campaignsWorkers)
			{
				await worker.StopAsync();
			}
		}
	}
}
