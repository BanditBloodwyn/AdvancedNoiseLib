using System;
using System.Collections.Generic;
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

        public Dictionary<Tuple<int, int>, Color> GenerateNoiseTexture(int size)
        {
            Dictionary<Tuple<int, int>, Color> dictionary = new Dictionary<Tuple<int, int>, Color>();

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    float value = _noiseEvaluator.Evaluate2D(x, y);
                    int grayscale = (int)(value * 255);
                    dictionary.Add(new Tuple<int, int>(x,y), Color.FromArgb(grayscale, grayscale, grayscale));
                }
            }
            return dictionary;
        }
    }
}