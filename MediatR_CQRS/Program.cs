using System;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_CQRS
{
    class Program
    {
        private readonly IMediator _mediator;

        public Program(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> CreateUser(CreateUserCommand createUserCmd)
        {
            return await _mediator.Send(createUserCmd);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
