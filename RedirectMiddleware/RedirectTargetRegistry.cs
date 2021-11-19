using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;

namespace RedirectMiddleware
{
    public class RedirectTargetRegistry : IRedirectTargetRegistry
    {
        private readonly Dictionary<string, string> _redirections;

        public RedirectTargetRegistry(IOptions<List<RedirectsMap>> redirects)
        {
            _redirections = redirects.Value.ToDictionary(x => x.Source, x => x.Destination);
        }

        public string FindDestinationRootAddress(string sourceRootAddress)
        {
            if (!_redirections.TryGetValue(sourceRootAddress, out string result))
            {
                return null;
            }

            return result;
        }
    }
}
