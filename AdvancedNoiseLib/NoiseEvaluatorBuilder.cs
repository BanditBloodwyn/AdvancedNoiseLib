﻿using AdvancedNoiseLib.Math.Noise;
using AdvancedNoiseLib.Settings;
using AdvancedNoiseLib.Utilities;

namespace AdvancedNoiseLib
{
    public class NoiseEvaluatorBuilder
    {
        private string _settingsJson = "";
        private int _seed;
        private bool _useFirstFilterLayerAsMask;

        public NoiseEvaluatorBuilder WithSettings(string settingsJson)
        {
            _settingsJson = settingsJson;
            return this;
        }

        public NoiseEvaluatorBuilder WithSeed(int seed)
        {
            _seed = seed;
            return this;
        }

        public NoiseEvaluatorBuilder ToUseFirstFilterLayerAsMask(bool useFirstFilterLayerAsMask)
        {
            _useFirstFilterLayerAsMask = useFirstFilterLayerAsMask;
            return this;
        }

        public INoiseEvaluator Build()
        {
            NoiseSettings settings = string.IsNullOrEmpty(_settingsJson) 
                ? new NoiseSettings()
                : NoiseSettingsParser.Parse(_settingsJson);
            PerlinNoiseEvaluator perlinNoise = new PerlinNoiseEvaluator(_seed);

            INoiseEvaluator evaluator = new NoiseEvaluator(settings, perlinNoise, _useFirstFilterLayerAsMask);
            return evaluator;
        }
    }
}
