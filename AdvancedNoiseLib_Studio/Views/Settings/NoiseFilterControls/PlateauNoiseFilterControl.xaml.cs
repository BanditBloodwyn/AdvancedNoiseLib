﻿using System.Windows.Controls;

namespace AdvancedNoiseLib_Studio.Views.Settings.NoiseFilterControls
{
    /// <summary>
    /// Interaktionslogik für PlateauNoiseFilterControl.xaml
    /// </summary>
    public partial class PlateauNoiseFilterControl : UserControl, INoiseFilterControl
    {
        public PlateauNoiseFilterControl()
        {
            InitializeComponent();
        }

        public string GetNoiseFilterJSON()
        {
            return null;
        }
    }
}
