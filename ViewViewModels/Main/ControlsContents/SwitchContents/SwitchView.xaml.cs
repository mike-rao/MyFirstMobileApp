using MyFirstMobileApp.ViewViewModels.Main.ControlsContents.SwitchContents;

namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.SwitchContents;

public partial class SwitchView : ContentPage
{
    public SwitchView()
    {
        InitializeComponent();
        BindingContext = new SwitchViewModel();
    }

    private void SwitchToggledFirst(object sender, ToggledEventArgs e1)
    {
        if (e1.Value == false)
        {
            //Red Color
            label1.TextColor = Color.FromRgb(255, 0, 0);
            label2.TextColor = Color.FromRgb(255, 0, 0);
        }
        else
        {
            //Blue Color
            label1.TextColor = Color.FromRgb(0, 0, 255);
            label2.TextColor = Color.FromRgb(0, 0, 255);
        }
    }

    private void SwitchToggledSecond(object sender, ToggledEventArgs e1)
    {
        if (e1.Value == false)
        {
            label1.TextColor = Color.FromRgb(255, 0, 255);
            label2.TextColor = Color.FromRgb(255, 0, 255);
        }
        else
        {
            label1.TextColor = Color.FromRgb(0, 255, 182);
            label2.TextColor = Color.FromRgb(0, 255, 182);
        }
    }
}


