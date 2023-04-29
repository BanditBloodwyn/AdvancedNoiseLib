using System.Drawing;
using System;

namespace AdvancedNoiseLib.Math.Noise.Filter
{
    public class RigidNoiseFilter : INoiseFilter
    {
        public int NumberOfLayers { get; set; }

        public float Strength { get; set; }
        public float Minimum { get; set; }
        public float Maximum { get; set; }

        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public float CenterZ { get; set; }

        public float BaseRoughness { get; set; }
        public float Roughness { get; set; }
        public float Persistance { get; set; }
        public float WeightMultiplier { get; set; }

        public float Evaluate(float x, float y, PerlinNoiseEvaluator noiseEvaluator)
        {
            float noiseValue = 0;
            float frequency = BaseRoughness;
            float amplitude = 1;
            float weight = 1;

            for (int i = 0; i < NumberOfLayers; i++)
            {
                float v = 1 - System.Math.Abs(noiseEvaluator.Evaluate(x * frequency + CenterX, 0, y * frequency + CenterZ ));

                v *= v;
                v *= weight;
                weight = System.Math.Clamp(v * WeightMultiplier, 0, 1);

                noiseValue += v * amplitude;
                frequency *= Roughness;
                amplitude *= Persistance;
            }

            noiseValue *= Strength;

            noiseValue = noiseValue >= Minimum
                ? noiseValue
                : Minimum;

            noiseValue = noiseValue <= Maximum
                ? noiseValue
                : Maximum;

            return noiseValue - Minimum;
        }
    }
}