namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.EntryContents;

public partial class EntryView : ContentPage
{
	public EntryView()
	{
		InitializeComponent();
        BindingContext = new EntryViewModel();
    }
}