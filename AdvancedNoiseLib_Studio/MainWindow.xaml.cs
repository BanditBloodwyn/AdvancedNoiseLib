using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using AdvancedNoiseLib;
using AdvancedNoiseLib_Studio.Helper;

namespace AdvancedNoiseLib_Studio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ctrl_Settings.GenerateRequested += GenerateRequested;
        }

        private void GenerateRequested(string settingsJson, int size)
        {
            Bitmap bitmap = BitmapGenerator.GenerateTexture(settingsJson, size);
            ctrl_Preview.SetTexture(bitmap);
        }
    }
}
