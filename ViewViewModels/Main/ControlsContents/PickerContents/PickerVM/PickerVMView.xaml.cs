namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.PickerContents.PickerVM;

public partial class PickerVMView : ContentPage
{
	public PickerVMView()
	{
		InitializeComponent();
		BindingContext = new PickerVMViewModel();
	}
}