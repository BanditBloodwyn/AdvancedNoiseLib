using System;
using System.Windows;
using System.Windows.Controls;

namespace AdvancedNoiseLib_Studio.Controls
{
    public partial class SettingsControl : UserControl
    {
        public event Action<string, int> GenerateRequested;

        public SettingsControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GenerateRequested.Invoke(GenerateSettingsJson(), (int)sld_size.Value);
        }

        private string GenerateSettingsJson()
        {
            return "";
        }
    }
}
