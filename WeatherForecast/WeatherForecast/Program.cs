// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace WeatherForecast
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                PrintMenu();
                var choice = DoChoice(0, 2);
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
                    case 0:
                        return;
                }

                Console.ReadKey();
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\t+-------------------------------------+\n" +
                              "\t\t\t\t\t\t\t\t|           choose an action          |\n" +
                              "\t\t\t\t\t\t\t\t|  1 - Weather forecast for today     |\n" +
                              "\t\t\t\t\t\t\t\t|  2 - Weather forecast for 5 days    |\n" +
                              "\t\t\t\t\t\t\t\t|  0 - Exit                           |\n" +
                              "\t\t\t\t\t\t\t\t+-------------------------------------+");
        }

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
        
        private static void ShowData(WeatherResponse weatherResponse)
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

        private static DateTime UnixTimestampToDateTime(long unixTime)
        {
            var unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var unixTimeStampInTicks = (unixTime * TimeSpan.TicksPerSecond);
            return new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
        }
    }
}