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
        Color[,] noiseTextureData = noiseTextureGenerator.GenerateNoiseTextureData(size);

        return GenerateBitmap(noiseTextureData, size);
    }

    private static Bitmap GenerateBitmap(Color[,] noiseTextureData, int size)
    {
        Bitmap bitmap = new(size, size);

        for (int x = 0; x < noiseTextureData.GetLength(0); x++)
        {
            for (int y = 0; y < noiseTextureData.GetLength(1); y++)
            {
                bitmap.SetPixel(x, y, noiseTextureData[x, y]);
            }
        }

        return bitmap;
    }
}