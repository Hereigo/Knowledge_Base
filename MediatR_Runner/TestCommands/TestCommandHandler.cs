using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_Runner.TestCommands
{
    public class TestCommandHandler : IRequestHandler<TestCommand>
    {
        public async Task<Unit> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            await Console.Out.WriteLineAsync($"TEST HANDLER runned at {DateTime.Now}");

            return Unit.Value;
        }
    }
}
