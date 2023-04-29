using System;
using System.Windows;
using AdvancedNoiseLib_Studio.ViewModels;

namespace AdvancedNoiseLib_Studio.Controls.Settings
{
    public partial class SettingsControl
    {
        public event Action<string, int>? GenerateRequested;

        public SettingsControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GenerateRequested?.Invoke(GenerateSettingsJson(), (int)sld_size.Value);
        }

        private string GenerateSettingsJson()
        {
            return "";
        }

        private void CreateNoiseFilter_Click(object sender, RoutedEventArgs e)
        {
            UIElement? noiseFilterControl = (DataContext as SettingsControlViewModel)?.CreateNoiseFilterControl();

            if (noiseFilterControl == null)
                return;

            pnl_NoiseFilters.Children.Add(noiseFilterControl);
            exp_NoiseFilters.IsExpanded = true;
        }
    }
}
