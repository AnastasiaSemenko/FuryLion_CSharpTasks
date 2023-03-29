// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace WeatherForecast
{
    public class WeatherResponse
    {
        public WindInfo Wind { get; set; }
        public TemperatureInfo Main { get; set; }
        public string Name { get; set; }
        public long Dt { get; set; }
    }
}