using AdvancedNoiseLib_Studio.Helper.Factories;
using System.Windows;
using AdvancedNoiseLib_Studio.Views.Settings;
using AdvancedNoiseLib_Studio.Views.Settings.NoiseFilterControls;

namespace AdvancedNoiseLib_Studio.Models;

public class SettingsControlModel
{
    public UIElement? CreateNoiseFilterControl()
    {
        NoiseFilterChoiceWindow choiceWindow = new();
        bool? result = choiceWindow.ShowDialog();

        if (result.HasValue && result.Value)
        {
            NoiseFilterControlFactory factory = new();
            INoiseFilterControl control = factory.CreateNoiseFilterControl(choiceWindow.ChosenType);

            if (control is UIElement uiElement)
                return uiElement;
            return null;
        }
        
        return null;
    }
}