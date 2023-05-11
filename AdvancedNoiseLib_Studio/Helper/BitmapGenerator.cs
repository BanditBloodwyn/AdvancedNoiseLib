using AdvancedNoiseLib;
using System.Drawing;

namespace AdvancedNoiseLib_Studio.Helper;

public static class BitmapGenerator
{
    public static Bitmap GenerateTexture(string settingsJson, int size)
    {
        NoiseEvaluatorBuilder noiseEvaluatorBuilder = new();
        INoiseEvaluator noiseEvaluator = noiseEvaluatorBuilder
            .WithSeed(0)
            .ToUseFirstFilterLayerAsMask(true)
            .WithSettings(settingsJson)
            .Build();

        NoiseTextureGenerator noiseTextureGenerator = new(noiseEvaluator);
        float[,] noiseTextureData = noiseTextureGenerator.GenerateNoiseTextureDataParallel(size);

        return GenerateBitmap(noiseTextureData, size);
    }

    private static Bitmap GenerateBitmap(float[,] noiseTextureData, int size)
    {
        Color[,] colors = ProcessData(noiseTextureData);

        Bitmap bitmap = new(size, size);

        for (int x = 0; x < noiseTextureData.GetLength(0); x++)
        {
            for (int y = 0; y < noiseTextureData.GetLength(1); y++)
            {
                bitmap.SetPixel(x, noiseTextureData.GetLength(1)-y-1, colors[x, y]);
            }
        }

        return bitmap;
    }

    private static Color[,] ProcessData(float[,] noiseTextureData)
    {
        Color[,] data = new Color[noiseTextureData.GetLength(0), noiseTextureData.GetLength(1)];
        ColorGradientSampler sampler = new ColorGradientSampler(new[] { Color.GreenYellow, Color.Red });

        for (int x = 0; x < noiseTextureData.GetLength(0); x++)
        {
            for (int y = 0; y < noiseTextureData.GetLength(1); y++)
            {
                data[x, y] = sampler.Sample(noiseTextureData[x, y]);
            }
        }

        return data;
    }
}