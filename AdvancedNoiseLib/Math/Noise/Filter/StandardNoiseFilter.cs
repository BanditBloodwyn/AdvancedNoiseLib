namespace AdvancedNoiseLib.Math.Noise.Filter
{
    public class StandardNoiseFilter : INoiseFilter
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

        public float Evaluate(float x, float y, PerlinNoiseEvaluator noiseEvaluator)
        {
            float noiseValue = 0;
            float frequency = BaseRoughness;
            float amplitude = 1;

            for (int i = 0; i < NumberOfLayers; i++)
            {
                float v = noiseEvaluator.Evaluate(x * frequency + CenterX, 0, y * frequency + CenterZ);
                noiseValue += (v + 1) * 0.5f * amplitude;
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

            noiseValue -= Minimum;

            return noiseValue;
        }
    }
}