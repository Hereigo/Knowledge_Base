using System;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_CQRS
{
    internal class AnEntryPoint
    {
        private readonly IMediator _mediator;

        public AnEntryPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> CreateUserAsync(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<User> GetUserAsync(GetUserQuery query)
        {
            return await _mediator.Send(query);
        }

        static void Main()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
