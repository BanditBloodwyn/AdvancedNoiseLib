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
                bitmap.SetPixel(x, y, colors[x, y]);
            }
        }

        return bitmap;
    }

    private static Color[,] ProcessData(float[,] noiseTextureData)
    {
        Color[,] data = new Color[noiseTextureData.GetLength(0), noiseTextureData.GetLength(1)];
        float maximum = GetMaximum(noiseTextureData);
        float minimum = GetMinimum(noiseTextureData);

        for (int x = 0; x < noiseTextureData.GetLength(0); x++)
        {
            for (int y = 0; y < noiseTextureData.GetLength(1); y++)
            {
                float g = ((noiseTextureData[x, y] - minimum) / maximum) * 255;
                int grayscale = (int)g;
                data[x, y] = Color.FromArgb(grayscale, grayscale, grayscale);
            }
        }

        return data;
    }

    private static float GetMinimum(float[,] noiseTextureData)
    {
        float minVal = float.MaxValue;

        for (int x = 0; x < noiseTextureData.GetLength(0); x++)
        {
            for (int y = 0; y < noiseTextureData.GetLength(1); y++)
            {
                if (noiseTextureData[x, y] < minVal)
                    minVal = noiseTextureData[x, y];
            }
        }

        return minVal;
    }

    private static float GetMaximum(float[,] noiseTextureData)
    {
        float maxVal = float.MinValue;

        for (int x = 0; x < noiseTextureData.GetLength(0); x++)
        {
            for (int y = 0; y < noiseTextureData.GetLength(1); y++)
            {
                if (noiseTextureData[x, y] > maxVal)
                    maxVal = noiseTextureData[x, y];
            }
        }

        return maxVal;
    }
}