using AdvancedNoiseLib.Math.Noise;
using AdvancedNoiseLib.Settings;

namespace AdvancedNoiseLib
{
    /// <summary>
    /// Calculates a float value for a given position.
    /// Cannot be instantiated directly. Use the NoiseEvaluatorBuilder.
    /// </summary>
    public class NoiseEvaluator : INoiseEvaluator
    {
        private readonly NoiseSettings _settings;
        private bool _useFirstFilterLayerAsMask;

        internal NoiseEvaluator(NoiseSettings settings, bool useFirstFilterLayerAsMask)
        {
            _settings = settings;
            _useFirstFilterLayerAsMask = useFirstFilterLayerAsMask;
        }

        public float Evaluate2D(float x, float y, PerlinNoiseEvaluator perlinNoise)
        {
            float firstLayerValue = 0;
            float elevation = 0;

            if (_settings.NoiseFilters.Length > 0)
            {
                firstLayerValue = _settings.NoiseFilters[0].Evaluate(x, y, perlinNoise);
                elevation = firstLayerValue;
            }

            if (_settings.NoiseFilters.Length == 1)
                return elevation;

            for (int i = 1; i < _settings.NoiseFilters.Length; i++)
                elevation += _settings.NoiseFilters[i].Evaluate(x, y, perlinNoise) * firstLayerValue;

            return elevation;
        }
    }
}
