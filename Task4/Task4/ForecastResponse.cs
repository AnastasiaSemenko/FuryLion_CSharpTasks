// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace Task4
{
    /// <summary>
    /// Прогноз погоды на 5 дней
    /// </summary>
    [Serializable]
    public class ForecastResponse
    {
        /// <summary>
        /// Массив ежедневных прогнозов 
        /// </summary>
        public WeatherResponse[] List { get; set; }
    }
}