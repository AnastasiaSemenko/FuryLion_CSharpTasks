// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace Task4
{
    /// <summary>
    /// Прогноз погоды на 1 день
    /// </summary>
    [Serializable]
    public class WeatherResponse
    {
        /// <summary>
        /// Информация о ветре
        /// </summary>
        public WindInfo Wind { get; set; }

        /// <summary>
        /// Информация о температуре воздуха
        /// </summary>
        public TemperatureInfo Main { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата прогназа погоды
        /// </summary>
        public long Dt { get; set; }
    }
}