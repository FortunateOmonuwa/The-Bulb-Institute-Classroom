using Temp_Converter.API.Models;

namespace Temp_Converter.API.Repository
{
    public class TemperateRepository : ITemperature
    {
        public string ConvertToCelsius(int temperature)
        {
            try
            {
                var result = (temperature - 32) * 5 / 9;
                return $"{result}^C";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ConvertToFahrenheit(int temperature)
        {
            try
            {
                var result =  (9 / 5) * temperature + 32;
                return $"{result}^F";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
