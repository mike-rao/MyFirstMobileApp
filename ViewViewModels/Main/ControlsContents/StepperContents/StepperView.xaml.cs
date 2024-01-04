using Microsoft.Maui.Controls;
using MyFirstMobileApp.ViewViewModels.Main.ControlsContents.StepperContets;
using System.ComponentModel.DataAnnotations;

namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.StepperContents;

public partial class StepperView : ContentPage
{
    private int theColor;
    private Color initialTextColor;

    public StepperView()
    {
        InitializeComponent();
        BindingContext = new StepperViewModel();
        initialTextColor = RotatingLabel.TextColor;
    }

    public void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
        RotatingLabel.Rotation = value;
        DisplayLabel.Text = string.Format("The Stepper value is {0}", value);
        theColor = (theColor + 30) % 360;
        Color newColor = ColorFromHsv(theColor, 1, 1);
        RotatingLabel.TextColor = newColor;

        double rotationAngle = stepper.Value;
        RotatingImage.Rotation = rotationAngle;
        RotatingImage.Background = newColor;
    }

    private Color ColorFromHsv(double hue, double saturation, double value)
    {
        int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
        double f = hue / 60 - Math.Floor(hue / 60);

        value *= 255;
        int v = Convert.ToInt32(value);
        int p = Convert.ToInt32(value * (1 - saturation));
        int q = Convert.ToInt32(value * (1 - f * saturation));
        int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

        if (hi == 0)
            return Color.FromRgb((byte)v, (byte)t, (byte)p);
        else if (hi == 1)
            return Color.FromRgb((byte)q, (byte)v, (byte)p);
        else if (hi == 2)
            return Color.FromRgb((byte)p, (byte)v, (byte)t);
        else if (hi == 3)
            return Color.FromRgb((byte)p, (byte)q, (byte)v);
        else if (hi == 4)
            return Color.FromRgb((byte)t, (byte)p, (byte)v);
        else
            return Color.FromRgb((byte)v, (byte)p, (byte)q);
    }
}


