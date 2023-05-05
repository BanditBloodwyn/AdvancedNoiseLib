using System.Globalization;
using System.Windows.Controls;

namespace AdvancedNoiseLib_Studio.Views.Settings.NoiseFilterControls
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
            string json =
                "{\n" +
                "Type : \"Standard\",\n" +
                $"NumberOfLayers : {(int)sld_NumberOfLayers.SliderValue},\n" +
                $"CenterX : {tb_CenterX.Text},\n" +
                $"CenterY : {tb_CenterY.Text},\n" +
                $"CenterZ : {tb_CenterZ.Text},\n" +
                $"Minimum : {sld_Minimum.SliderValue.ToString(CultureInfo.InvariantCulture)},\n" +
                $"Maximum : {sld_Maximum.SliderValue.ToString(CultureInfo.InvariantCulture)},\n" +
                $"Strength : {sld_Strength.SliderValue.ToString(CultureInfo.InvariantCulture)},\n" +
                $"BaseRoughness : {sld_BaseRoughness.SliderValue.ToString(CultureInfo.InvariantCulture)},\n" +
                $"Roughness : {sld_Roughness.SliderValue.ToString(CultureInfo.InvariantCulture)},\n" +
                $"Persistance : {sld_Persistance.SliderValue.ToString(CultureInfo.InvariantCulture)}\n" +
                "}\n";
            return json;
        }
    }
}
