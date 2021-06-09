using System;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_CQRS
{
    class A_Program
    {
        private readonly IMediator _mediator;

        public A_Program(IMediator mediator)
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
