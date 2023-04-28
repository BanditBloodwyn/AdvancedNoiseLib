using System;
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
        private NoiseSettings _settings;
        private int _seed;
        private bool _useFirstFilterLayerAsMask;

        internal NoiseEvaluator(NoiseSettings settings, int seed, bool useFirstFilterLayerAsMask)
        {
            _settings = settings;
            _seed = seed;
            _useFirstFilterLayerAsMask = useFirstFilterLayerAsMask;
        }

        public float Evaluate2D(float x, float y)
        {
            PerlinNoiseEvaluator perlinNoise = new PerlinNoiseEvaluator();

            Random random = new Random();

            return (float)random.NextDouble();
        }
    }
}
