using AdvancedNoiseLib_Studio.Controls.Settings.NoiseFilterControls;
using System;
using System.Windows;

namespace AdvancedNoiseLib_Studio.Controls.Settings
{
    /// <summary>
    /// Interaktionslogik für NoiseFilterChoiceWindow.xaml
    /// </summary>
    public partial class NoiseFilterChoiceWindow : Window
    {
        public NoiseFilterTypes ChosenType => (NoiseFilterTypes)cmb_Choice.SelectedValue;

        public NoiseFilterChoiceWindow()
        {
            InitializeComponent();

            foreach (NoiseFilterTypes filterType in (NoiseFilterTypes[])Enum.GetValues(typeof(NoiseFilterTypes)))
                cmb_Choice.Items.Add(filterType);

            cmb_Choice.SelectedIndex = 0;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
