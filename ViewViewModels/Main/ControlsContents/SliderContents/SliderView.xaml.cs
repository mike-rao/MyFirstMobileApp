

namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.SliderContents;

public partial class SliderView : ContentPage
{
    public SliderView()
    {
        InitializeComponent();
        BindingContext = new SliderViewModel();
        this.SetPadding();
    }

    private void SetPadding()
    {
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            Padding = new Thickness(25);
        }
        else if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            Padding = new Thickness(25);
        }
    }
}

