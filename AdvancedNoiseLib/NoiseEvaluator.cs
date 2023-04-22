﻿using AdvancedNoiseLib.Math.Noise;
using AdvancedNoiseLib.Settings;

namespace AdvancedNoiseLib
{
    public class NoiseEvaluator : INoiseEvaluator
    {
        private NoiseSettings _settings;
        private int _seed;
        private bool _useFirstFilterLayerAsMask;

        public NoiseEvaluator(NoiseSettings settings, int seed, bool useFirstFilterLayerAsMask)
        {
            _settings = settings;
            _seed = seed;
            _useFirstFilterLayerAsMask = useFirstFilterLayerAsMask;
        }

        public float Evaluate2D(float x, float y)
        {
            PerlinNoiseEvaluator perlinNoise = new PerlinNoiseEvaluator();
            return 0;
        }
    }
}
