using System;
using System.Collections.Generic;
using AdvancedNoiseLib.Math.Noise.Filter;
using AdvancedNoiseLib.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdvancedNoiseLib.Utilities
{
    public static class NoiseSettingsParser
    {
        public static NoiseSettings Parse(string settingsJson)
        {
            NoiseSettings noiseSettings = new NoiseSettings
            {
                NoiseFilters = ParseNoiseFilters(settingsJson)
            };

            return noiseSettings;
        }

        private static INoiseFilter[] ParseNoiseFilters(string settingsJson)
        {
            List<INoiseFilter> noiseFilters = new List<INoiseFilter>();
            JArray jsonArray = JArray.Parse(settingsJson);
            
            foreach (JObject jsonObject in jsonArray)
            {
                if(jsonObject == null)
                    continue;

                string? type = jsonObject.GetValue("Type")?.ToString();
                if(string.IsNullOrEmpty(type))
                    continue;

                INoiseFilter noiseFilter = type switch
                {
                    "Standard" => new StandardNoiseFilter(),
                    "Rigid" => new RigidNoiseFilter(),
                    "Plateau" => new PlateauNoiseFilter(),
                    _ => throw new ArgumentOutOfRangeException()
                };

                JsonConvert.PopulateObject(jsonObject.ToString(), noiseFilter);

                noiseFilters.Add(noiseFilter);
            }

            return noiseFilters.ToArray();
        }
    }
}