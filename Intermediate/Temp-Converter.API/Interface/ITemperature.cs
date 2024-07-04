namespace Temp_Converter.API.Models
{
    public interface ITemperature
    {
        string ConvertToFahrenheit(int temperature);
        string ConvertToCelsius(int temperature);
    }
}
