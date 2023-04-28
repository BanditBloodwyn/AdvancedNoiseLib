using AdvancedNoiseLib.Math.Noise;
using System;
using System.Drawing;

namespace AdvancedNoiseLib
{
    public class NoiseTextureGenerator
    {
        private readonly INoiseEvaluator _noiseEvaluator;

        public NoiseTextureGenerator(INoiseEvaluator noiseEvaluator)
        {
            _noiseEvaluator = noiseEvaluator;
        }

        public Color[,] GenerateNoiseTextureData(int size)
        {
            Color[,] data = new Color[size, size];

            Random random = new Random();
            PerlinNoiseEvaluator perlinNoise = new PerlinNoiseEvaluator(random.Next(int.MaxValue));

            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    float value = (_noiseEvaluator.Evaluate2D(x, y, perlinNoise) + 1) / 2;
                    int grayscale = (int)(value * 255);

                    data[x, y] = Color.FromArgb(grayscale, grayscale, grayscale);
                }
            }

            return data;
        }

    }
}