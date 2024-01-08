namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.PickerContents;

public partial class PickerView : ContentPage
{
	public PickerView()
	{
		InitializeComponent();
		BindingContext = new PickerViewModel();
	}
}