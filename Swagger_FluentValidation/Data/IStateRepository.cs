using System.Threading;
using System.Threading.Tasks;

namespace Swagger_FluentValidation.Data
{
    internal interface IStateRepository
    {
        string GetState(string state);
        Task<string> GetStateAsync(string abbreviation, CancellationToken token);
    }
}