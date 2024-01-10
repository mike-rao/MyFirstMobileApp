namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.DatePickerContents;

public partial class DatePickerView : ContentPage
{
	public DatePickerView()
	{
		InitializeComponent();
		BindingContext = new DatePickerViewModel();
	}
}