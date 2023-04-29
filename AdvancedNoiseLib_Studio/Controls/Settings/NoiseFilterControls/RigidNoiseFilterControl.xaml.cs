using System.Windows.Controls;

namespace AdvancedNoiseLib_Studio.Controls.Settings.NoiseFilterControls
{
    /// <summary>
    /// Interaktionslogik für StandardNoiseFilterControl.xaml
    /// </summary>
    public partial class RigidNoiseFilterControl : UserControl, INoiseFilterControl
    {
        public RigidNoiseFilterControl()
        {
            InitializeComponent();
        }

        public string GetNoiseFilterJSON()
        {
            return null;
        }
    }
}
