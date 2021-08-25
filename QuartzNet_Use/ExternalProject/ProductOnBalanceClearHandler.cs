using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ExternalProject
{
    public class ProductOnBalanceClearHandler : IRequestHandler<ProductOnBalanceClear>
    {
        //private readonly IUnitOfWork _unitOfWork;

        //public ProductOnBalanceClearHandler(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        public async Task<Unit> Handle(ProductOnBalanceClear request, CancellationToken cancellationToken)
        {
            Task.Delay(TimeSpan.FromSeconds(2));

            await Console.Out.WriteLineAsync($"Time is {DateTime.Now}");

            return Unit.Value;
        }
    }
}