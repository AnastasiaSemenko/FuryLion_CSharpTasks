// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Net;
using Newtonsoft.Json;

namespace Task4
{
    /// <summary>
    /// Класс для загрузки данных 
    /// </summary>
    public static class DataDownloader
    {
        private static string _weatherResponsesFilePath =
            @"D:\Programs\Not games\fork\a.semenko\Task4\Task4\WeatherResponses.txt";

        private static string _forecastResponsesFilePath =
            @"D:\Programs\Not games\fork\a.semenko\Task4\Task4\ForecastResponses.txt";

        /// <summary>
        /// Словарь с прогнозами на 1 день
        /// </summary>
        private static ObservableDictionary<string, WeatherResponse> _weatherResponses = new();

        /// <summary>
        /// Словарь с прогнозами на 5 дней
        /// </summary>
        private static ObservableDictionary<string, ForecastResponse> _forecastResponses = new();

        /// <summary>
        /// Инициализация словарей 
        /// </summary>
        public static void Init()
        {
            _weatherResponses.InitDictionary(_weatherResponsesFilePath);
            _forecastResponses.InitDictionary(_forecastResponsesFilePath);
            _weatherResponses.DataChanged += Storage.Save;
            _forecastResponses.DataChanged += Storage.Save;
        }

        /// <summary>
        /// Загрузка погоды на 1 день
        /// </summary>
        /// <param name="cityName">Название города</param>
        /// <param name="received">Событие</param>
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

            if (_weatherResponses.ContainsKey(cityName))
                _weatherResponses[cityName] = weatherResponse;
            else
                _weatherResponses.Add(cityName, weatherResponse);

            received?.Invoke(weatherResponse);
        }

        /// <summary>
        /// Загрузка погоды на 5 дней
        /// </summary>
        /// <param name="cityName">Название города</param>
        /// <param name="received">Событие</param>
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

            if (_forecastResponses.ContainsKey(cityName))
                _forecastResponses[cityName] = forecastResponse;
            else
                _forecastResponses.Add(cityName, forecastResponse);

            for (var index = 0; index < forecastResponse.List.Length; index += 8)
            {
                forecastResponse.List[index].Name = cityName;
                received?.Invoke(forecastResponse.List[index]);
            }
        }

        /// <summary>
        /// Метод запроса данных
        /// </summary>
        /// <param name="url">Ссылка запроса</param>
        /// <returns>Возвращает json ответ в строке</returns>
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

        /// <summary>
        /// Выводит всю информацию из кэша
        /// </summary>
        public static void ShowAllWeather()
        {
            foreach (var weather in _weatherResponses)
                Program.ShowData(weather.Value);

            foreach (var forecast in _forecastResponses)
                foreach (var weather in forecast.Value.List)
                    Program.ShowData(weather);
        }
    }
}