using System.Windows.Controls;

namespace AdvancedNoiseLib_Studio.Controls.Settings.NoiseFilterControls
{
    /// <summary>
    /// Interaktionslogik für StandardNoiseFilterControl.xaml
    /// </summary>
    public partial class StandardNoiseFilterControl : UserControl, INoiseFilterControl
    {
        public StandardNoiseFilterControl()
        {
            InitializeComponent();
        }

        public string GetNoiseFilterJSON()
        {
            return null;
        }
    }
}
