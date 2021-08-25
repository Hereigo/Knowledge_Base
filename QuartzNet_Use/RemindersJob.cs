using System.Threading.Tasks;
using ExternalProject;
using MediatR;
using Quartz;

namespace QuartzNet_Use
{
    public class RemindersJob : IJob
    {
        private readonly IMediator _mediator;

        public RemindersJob(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return _mediator.Send(new ProductOnBalanceClear());
        }
    }
}
