using AdvancedNoiseLib.Math.Noise;

namespace AdvancedNoiseLib
{
    public interface INoiseEvaluator
    {
        public float Evaluate2D(float x, float y, PerlinNoiseEvaluator perlinNoise);
    }
}
