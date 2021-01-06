using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.Options;
using WsdlCore.Interfaces;
using WsdlCore.Models;

namespace WsdlCore.Repositories
{
    public class TempConvertRepository : ITempConvertRepository
    {
        private readonly ITempConvertChannel _proxy;

        public TempConvertRepository(IOptions<ClientConfig> config)
        {
            var cfg = config.Value;
            /*
             * Create & Configure Client
             */
            BasicHttpBinding binding = new BasicHttpBinding
            {
                SendTimeout = TimeSpan.FromSeconds(cfg.Timeout),
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
                AllowCookies = true,
                ReaderQuotas = XmlDictionaryReaderQuotas.Max
            };
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            EndpointAddress address = new EndpointAddress(cfg.Url);
            ChannelFactory<ITempConvertChannel> factory = new ChannelFactory<ITempConvertChannel>(binding, address);
            this._proxy = factory.CreateChannel();
        }

        public async Task<string> FahrenheitToCelsiusAsync(string fahrenheit)
        {
            return await _proxy.FahrenheitToCelsiusAsync(fahrenheit);
        }

        public async Task<string> CelsiusToFahrenheitAsync(string celsius)
        {
            return await _proxy.CelsiusToFahrenheitAsync(celsius);
        }
    }
}