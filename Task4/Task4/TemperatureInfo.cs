// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace Task4
{
    /// <summary>
    /// Информация о темпаратуре воздуха
    /// </summary>
    [Serializable]
    public class TemperatureInfo
    {
        /// <summary>
        /// Фактическая температура воздуха
        /// </summary>
        public float Temp { get; set; }

        /// <summary>
        /// Как ощущается температура воздуха
        /// </summary>
        public float Feels_like { get; set; }
    }
}