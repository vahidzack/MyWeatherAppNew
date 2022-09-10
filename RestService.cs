
using Newtonsoft.Json;

using WeatherApp;
using Debug = System.Diagnostics.Debug;

namespace MyWeatherApp
{
    public class RestService
    {
        HttpClient _httpClient;


        public RestService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherData(string query)
        {
            WeatherData weatherData = null;
            try
            {
                var response = await _httpClient.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var Content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(Content);
                }



            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message); 
                throw;
            }
            return weatherData;
        }
    }
}
