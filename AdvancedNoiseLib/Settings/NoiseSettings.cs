using System;
using AdvancedNoiseLib.Math.Noise.Filter;

namespace AdvancedNoiseLib.Settings
{
    public class NoiseSettings
    {
        public INoiseFilter[] NoiseFilters = Array.Empty<INoiseFilter>();
    }
}