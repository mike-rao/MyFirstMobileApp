namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents;

public partial class ControlsView : ContentPage
{
	public ControlsView()
	{
		InitializeComponent();
		BindingContext = new ControlsViewModel();
	}
}