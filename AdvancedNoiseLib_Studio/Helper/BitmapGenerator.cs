using AdvancedNoiseLib;
using System;
using System.Collections.Generic;
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
        Dictionary<Tuple<int, int>, Color> noiseTextureDictionary = noiseTextureGenerator.GenerateNoiseTexture(size);

        return GenerateBitmap(noiseTextureDictionary, size);
    }

    private static Bitmap GenerateBitmap(Dictionary<Tuple<int, int>, Color> data, int size)
    {
        Bitmap bitmap = new(size, size);
        
        Console.WriteLine($"create Bitmap. Size = {size}");

        foreach (KeyValuePair<Tuple<int, int>, Color> dataSet in data)
            bitmap.SetPixel(dataSet.Key.Item1, dataSet.Key.Item2, dataSet.Value);

        return bitmap;
    }
}