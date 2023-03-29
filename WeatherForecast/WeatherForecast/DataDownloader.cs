// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Net;
using Newtonsoft.Json;

namespace WeatherForecast
{
    public static class DataDownloader
    {
        public static async void DownloadWeather(string cityName, Action<WeatherResponse> received)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}" +
                      "&units=metric&appid=8163ea7b0457263534b97487a291fe21";
            var response = await DoResponse(url);
            
            if (string.IsNullOrEmpty(response))
                return;
            
            var weatherResponse = new WeatherResponse();
            
            try
            {
                weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            }
            catch (JsonException _)
            {
                Console.WriteLine("\t\t\t\t\t\t\t\t--> something wrong :( <--");
                return;
            }
            
            received?.Invoke(weatherResponse);
        }

        public static async void DownloadForecast(string cityName, Action<WeatherResponse> received)
        {
            var url = $"https://api.openweathermap.org/data/2.5/forecast?q={cityName}" +
                      "&units=metric&appid=8163ea7b0457263534b97487a291fe21";
            var response = await DoResponse(url);
            
            if (string.IsNullOrEmpty(response))
                return;
            
            var forecastResponse = new ForecastResponse();
            
            try
            {
                forecastResponse = JsonConvert.DeserializeObject<ForecastResponse>(response);
            }
            catch (JsonSerializationException _)
            {
                Console.WriteLine("\t\t\t\t\t\t\t\t--> something wrong :( <--");
                return;
            }

            for (var index = 0; index < forecastResponse.List.Length; index += 8)
            {
                forecastResponse.List[index].Name = cityName;
                received?.Invoke(forecastResponse.List[index]);
            }
        }

        private static async Task<string> DoResponse(string url)
        {
            using var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(url);
            
            if (result.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("\t\t\t\t\t\t\t--> something wrong. This city not found :( <--");
                return string.Empty;
            }
            
            using var streamReader = new StreamReader(await httpClient.GetStreamAsync(url));
            return await streamReader.ReadToEndAsync();
        }
    }
}