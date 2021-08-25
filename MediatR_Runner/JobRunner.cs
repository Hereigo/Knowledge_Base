using System;
using System.Threading.Tasks;
using MediatR;
using MediatR_Runner.TestCommands;
using MediatR_Runner_Ext;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MediatR_Runner
{
    public class JobRunner
    {
        private readonly ILogger<JobRunner> _logger;
        private readonly AppSettings _settings;

        private readonly IMediator _mediator;

        public JobRunner(IMediator mediator, IOptions<AppSettings> settings, ILogger<JobRunner> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator;
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task Run(string[] args)
        {
            _logger.LogInformation("Starting...");

            try
            {
                if (_settings.TestJob)
                {
                    Console.WriteLine($"TEST-JOB Executed: {DateTime.Now}");
                    await _mediator.Send(new TestCommand());
                }
                if (_settings.Job2)
                {
                    Console.WriteLine($"JOB-2 Executed: {DateTime.Now}");
                    await _mediator.Send(new ProductOnBalanceClear());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            _logger.LogInformation("Finished!");

            await Task.CompletedTask;
        }
    }
}
