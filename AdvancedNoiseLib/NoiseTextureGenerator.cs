using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace AdvancedNoiseLib
{
    public class NoiseTextureGenerator
    {
        private readonly INoiseEvaluator _noiseEvaluator;

        public NoiseTextureGenerator(INoiseEvaluator noiseEvaluator)
        {
            _noiseEvaluator = noiseEvaluator;
        }

        public float[,] GenerateNoiseTextureDataParallel(int size)
        {
            float[,] data = new float[size, size];

            int minPartitionSize = System.Math.Max(size / Environment.ProcessorCount, 1);
            var partitioner = Partitioner.Create(0, size, minPartitionSize);

            Parallel.ForEach(partitioner, range =>
            {
                for (int x = range.Item1; x < range.Item2; x++)
                {
                    for (int y = 0; y < data.GetLength(1); y++)
                    {
                        float value = (_noiseEvaluator.Evaluate2D(x, y) + 1) / 2;

                        data[x, y] = value;
                    }
                }
            });

            return data;
        }
    }
}