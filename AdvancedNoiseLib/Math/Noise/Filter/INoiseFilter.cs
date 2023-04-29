namespace AdvancedNoiseLib.Math.Noise.Filter
{
    public interface INoiseFilter
    {
        public float Evaluate(float x, float y, PerlinNoiseEvaluator noiseEvaluator);
    }
}