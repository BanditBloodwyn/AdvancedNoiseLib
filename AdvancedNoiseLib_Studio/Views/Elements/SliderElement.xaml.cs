using System.Windows;
using System.Windows.Controls;

namespace AdvancedNoiseLib_Studio.Views.Elements
{
    /// <summary>
    /// Interaktionslogik für SliderElement.xaml
    /// </summary>
    public partial class SliderElement : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(SliderElement),
            new PropertyMetadata("Title")); 

        public static readonly DependencyProperty SliderMinimumProperty = DependencyProperty.Register(
            nameof(SliderMinimum),
            typeof(float),
            typeof(SliderElement),
            new PropertyMetadata(0f));

        public static readonly DependencyProperty SliderMaximumProperty = DependencyProperty.Register(
            nameof(SliderMaximum),
            typeof(float),
            typeof(SliderElement),
            new PropertyMetadata(100f));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public float SliderMinimum
        {
            get => (float)GetValue(SliderMinimumProperty);
            set => SetValue(SliderMinimumProperty, value);
        }

        public float SliderMaximum
        {
            get => (float)GetValue(SliderMaximumProperty);
            set => SetValue(SliderMaximumProperty, value);
        }

        public float SliderValue
        {
            get => (float)sld_Value.Value;
            set => sld_Value.Value = value;
        }

        public SliderElement()
        {
            InitializeComponent();
        }
    }
}
