using System;
using AdvancedNoiseLib_Studio.Views.Settings.NoiseFilterControls;

namespace AdvancedNoiseLib_Studio.Helper.Factories;

public class NoiseFilterControlFactory
{
    public INoiseFilterControl CreateNoiseFilterControl(NoiseFilterTypes filterType)
    {
        return filterType switch
        {
            NoiseFilterTypes.Standard => new StandardNoiseFilterControl(),
            NoiseFilterTypes.Rigid => new RigidNoiseFilterControl(),
            NoiseFilterTypes.Plateau => new PlateauNoiseFilterControl(),

            _ => throw new ArgumentOutOfRangeException(nameof(filterType), filterType, null)
        };
    }
}