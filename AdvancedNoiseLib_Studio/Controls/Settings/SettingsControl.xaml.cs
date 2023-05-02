using AdvancedNoiseLib_Studio.Controls.Settings.NoiseFilterControls;
using AdvancedNoiseLib_Studio.ViewModels;
using System;
using System.Windows;

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
            string json = GenerateSettingsJson();

            if (string.IsNullOrEmpty(json))
                return;

            GenerateRequested?.Invoke(json, (int)se_Size.SliderValue);
        }

        private string GenerateSettingsJson()
        {
            string json = "[\n";
            foreach (UIElement uiElement in pnl_NoiseFilters.Children)
            {
                if (uiElement is INoiseFilterControl filterControl)
                    json += filterControl.GetNoiseFilterJSON() + ",\n";
            }

            json.TrimEnd(',');
            json += "\n]";

            return json;
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
