using System;
using System.Drawing;

namespace AdvancedNoiseLib_Studio.Helper;

public class ColorGradientSampler
{
    private readonly Color[] _gradient;

    public ColorGradientSampler(Color[] gradient)
    {
        _gradient = gradient;
    }

    public Color Sample(float value)
    {
        if(value == 0)
            return Color.CornflowerBlue;

        float position = value / 22f;
       
        if(position > 1)
            return Color.White;

        int index = (int)Math.Floor(position * (_gradient.Length - 1));
        float fraction = (position * (_gradient.Length - 1)) % 1;

        Color color = Color.FromArgb(
            (int)Math.Round((1 - fraction) * _gradient[index].R + fraction * _gradient[index + 1].R),
            (int)Math.Round((1 - fraction) * _gradient[index].G + fraction * _gradient[index + 1].G),
            (int)Math.Round((1 - fraction) * _gradient[index].B + fraction * _gradient[index + 1].B)
        );

        return color;
    }
}