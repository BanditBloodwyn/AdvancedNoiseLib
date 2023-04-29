using AdvancedNoiseLib_Studio.Core.MVVM;
using AdvancedNoiseLib_Studio.Models;
using System.Windows;

namespace AdvancedNoiseLib_Studio.ViewModels;

public class SettingsControlViewModel : ObservableObject
{
    private readonly SettingsControlModel _model;

    public SettingsControlViewModel()
    {
        _model = new SettingsControlModel();
    }

    public UIElement? CreateNoiseFilterControl()
    {
        return _model.CreateNoiseFilterControl();
    }
}