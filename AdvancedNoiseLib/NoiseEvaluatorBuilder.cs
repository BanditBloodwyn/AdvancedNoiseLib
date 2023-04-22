using AdvancedNoiseLib.Settings;
using AdvancedNoiseLib.Utilities;

namespace AdvancedNoiseLib
{
    public class NoiseEvaluatorBuilder
    {
        private string _settings = "";
        private int _seed;
        private bool _useFirstFilterLayerAsMask;

        public NoiseEvaluatorBuilder WithSettings(string settings)
        {
            _settings = settings;
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

        public NoiseEvaluator Build()
        {
            NoiseSettings settings = string.IsNullOrEmpty(_settings) 
                ? new NoiseSettings()
                : NoiseSettingsParser.Parse(_settings);

            NoiseEvaluator evaluator = new NoiseEvaluator(settings, _seed, _useFirstFilterLayerAsMask);
            return evaluator;
        }
    }
}
