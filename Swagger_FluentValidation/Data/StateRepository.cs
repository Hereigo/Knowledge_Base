using System.Threading;
using System.Threading.Tasks;

namespace Swagger_FluentValidation.Data
{
    public class StateRepository : IStateRepository
    {
        public string GetState(string state)
        {
            return state;
        }

        public async Task<string> GetStateAsync(string abbreviation, CancellationToken token)
        {
            return await GetAbbreviationAsync(abbreviation);
        }

        private async Task<string> GetAbbreviationAsync(string abbr)
        {
            return abbr;
        }
    }
}