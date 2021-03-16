using System.Threading.Tasks;

namespace WsdlCore.Interfaces
{
    public interface ITempConvertRepository
    {
        Task<string> FahrenheitToCelsiusAsync(string fahrenheit);
        Task<string> CelsiusToFahrenheitAsync(string celsius);
    }
}