using System.Threading.Tasks;

namespace WsdlCore.Interfaces
{
    
    [System.ServiceModel.ServiceContractAttribute(
        Namespace="https://www.w3schools.com/xml/", 
        ConfigurationName="TempConvert.Interfaces.ITempConvert")]
    public interface ITempConvert
    {
        
        [System.ServiceModel.OperationContractAttribute(
            Action="https://www.w3schools.com/xml/FahrenheitToCelsius", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<string> FahrenheitToCelsiusAsync(string Fahrenheit);
        
        [System.ServiceModel.OperationContractAttribute(
            Action="https://www.w3schools.com/xml/CelsiusToFahrenheit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<string> CelsiusToFahrenheitAsync(string Celsius);
    }
}