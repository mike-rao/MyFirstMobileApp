namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.PickerContents.PickerXAML;

public partial class PickerXAMLView : ContentPage
{
	public PickerXAMLView()
	{
		InitializeComponent();
		BindingContext = new PickerXAMLViewModel();
	}
}