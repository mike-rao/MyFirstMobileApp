namespace MyFirstMobileApp.ViewViewModels.Main.CollectionsContents;

public partial class CollectionsView : ContentPage
{
	public CollectionsView()
	{
		InitializeComponent();
		BindingContext = new CollectionsViewModel();
	}
}