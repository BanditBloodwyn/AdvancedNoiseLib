using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace AdvancedNoiseLib_Studio.Controls
{
    public partial class NoisePreviewControl : UserControl
    {
        public NoisePreviewControl()
        {
            InitializeComponent();
        }

        public void SetTexture(Bitmap bitmap)
        {
            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                bitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            img_Preview.Source = bitmapSource;
        }
    }
}
