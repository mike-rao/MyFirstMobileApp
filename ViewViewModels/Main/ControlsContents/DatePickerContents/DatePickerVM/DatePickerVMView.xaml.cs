namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.DatePickerContents.DatePickerVM;

public partial class DatePickerVMView : ContentPage
{
	public DatePickerVMView()
	{
		InitializeComponent();
		BindingContext = new DatePickerVMViewModel();
	}
}