// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Runtime.Serialization;

namespace Task4
{
    /// <summary>
    /// Главный класс прогрммы
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Главный метод программы
        /// </summary>
        public static void Main()
        {
            DataDownloader.Init();
            
            while (true)
            {
                PrintMenu();
                var choice = DoChoice(0, 3);
                var city = "";

                switch (choice)
                {
                    case 1:
                        city = SelectCity();
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\tLoading... Please, wait");
                        DataDownloader.DownloadWeather(city, ShowData);
                        break;
                    case 2:
                        city = SelectCity();
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\tLoading... Please, wait");
                        DataDownloader.DownloadForecast(city, ShowData);
                        break;
                    case 3:
                        DataDownloader.ShowAllWeather();
                        break;
                    case 0:
                        return;
                }

                Console.ReadKey();
            }
        }

        /// <summary>
        /// Вывод меню на экран
        /// </summary>
        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\t+----------------------------------------+\n" +
                              "\t\t\t\t\t\t\t\t|           choose an action             |\n" +
                              "\t\t\t\t\t\t\t\t|  1 - Weather forecast for today        |\n" +
                              "\t\t\t\t\t\t\t\t|  2 - Weather forecast for 5 days       |\n" +
                              "\t\t\t\t\t\t\t\t|  3 - (offline)Latest weather forecasts |\n" +
                              "\t\t\t\t\t\t\t\t|  0 - Exit                              |\n" +
                              "\t\t\t\t\t\t\t\t+----------------------------------------+");
        }

        /// <summary>
        /// Вывод списка городов на экран
        /// </summary>
        private static void PrintCities()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\t+-------------------------------------+\n" +
                              "\t\t\t\t\t\t\t\t|            choose a city            |\n" +
                              $"\t\t\t\t\t\t\t\t|           1 - {Cities.Berlin}                |\n" +
                              $"\t\t\t\t\t\t\t\t|           2 - {Cities.London}                |\n" +
                              $"\t\t\t\t\t\t\t\t|           3 - {Cities.Moscow}                |\n" +
                              $"\t\t\t\t\t\t\t\t|           4 - {Cities.Minsk}                 |\n" +
                              $"\t\t\t\t\t\t\t\t|           5 - {Cities.Tokio}                 |\n" +
                              $"\t\t\t\t\t\t\t\t|           6 - other city            |\n" +
                              "\t\t\t\t\t\t\t\t+-------------------------------------+");
        }

        /// <summary>
        /// Выбор значений в указанном диапазоне
        /// </summary>
        /// <param name="from">От</param>
        /// <param name="to">До</param>
        /// <returns>Корректное начение</returns>
        private static int DoChoice(int from, int to)
        {
            while (true)
            {
                Console.Write("\t\t\t\t\t\t\t\tyour choice --> ");

                if (int.TryParse(Console.ReadLine(), out var choice) && choice >= from && choice <= to)
                {
                    Console.Clear();
                    return choice;
                }

                Console.WriteLine($"\t\t\t\t\t\t\t\tYou must enter a number from {from} to {to}");
            }
        }

        /// <summary>
        /// Метод для выбора города
        /// </summary>
        /// <returns>Выбранный город</returns>
        private static string SelectCity()
        {
            Console.Clear();
            PrintCities();
            var choice = DoChoice(1, 6);
            var city = "";

            switch (choice)
            {
                case 1:
                    city = Cities.Berlin.ToString();
                    break;
                case 2:
                    city = Cities.London.ToString();
                    break;
                case 3:
                    city = Cities.Moscow.ToString();
                    break;
                case 4:
                    city = Cities.Minsk.ToString();
                    break;
                case 5:
                    city = Cities.Tokio.ToString();
                    break;
                case 6:
                    Console.Write("\t\t\t\t\t\t\t\tPlease enter the city --> ");
                    city = Console.ReadLine() ?? string.Empty;
                    break;
            }

            return city;
        }

        /// <summary>
        /// Вывод прогноза погоды на 1 день
        /// </summary>
        /// <param name="weatherResponse">Прогноз погодв</param>
        public static void ShowData(WeatherResponse weatherResponse)
        {
            Console.WriteLine("\t\t\t\t\t\t\t\t+-----------------------------------------------+\n" +
                              $"\t\t\t\t\t\t\t\t|   Weather in {weatherResponse.Name} at {UnixTimestampToDateTime(weatherResponse.Dt)}\t|\n" +
                              "\t\t\t\t\t\t\t\t+-----------------------------------------------+\n" +
                              $"\t\t\t\t\t\t\t\t|             Temperature - {weatherResponse.Main.Temp} C           \t|\n" +
                              $"\t\t\t\t\t\t\t\t|              Feels like - {weatherResponse.Main.Feels_like} C           \t|\n" +
                              "\t\t\t\t\t\t\t\t+-----------------------------------------------+\n" +
                              $"\t\t\t\t\t\t\t\t|              Wind Speed - {weatherResponse.Wind.Speed} m/s       \t|\n" +
                              "\t\t\t\t\t\t\t\t+-----------------------------------------------+\n");
        }

        /// <summary>
        /// Перевод даты из Unix времни
        /// </summary>
        /// <param name="unixTime">время в unix</param>
        /// <returns>дата</returns>
        private static DateTime UnixTimestampToDateTime(long unixTime)
        {
            var unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var unixTimeStampInTicks = (unixTime * TimeSpan.TicksPerSecond);
            return new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
        }
    }
}