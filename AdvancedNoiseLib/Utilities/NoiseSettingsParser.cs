using System;
using AdvancedNoiseLib.Math.Noise.Filter;
using AdvancedNoiseLib.Settings;

namespace AdvancedNoiseLib.Utilities
{
    public static class NoiseSettingsParser
    {
        public static NoiseSettings Parse(string settingsFileText)
        {
            NoiseSettings noiseSettings = new NoiseSettings
            {
                NoiseFilters = ParseNoiseFilters(settingsFileText)
            };

            return noiseSettings;
        }

        private static INoiseFilter[] ParseNoiseFilters(string settingsFileText)
        {
            return Array.Empty<INoiseFilter>();
        }
    }
}