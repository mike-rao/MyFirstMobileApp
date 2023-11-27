namespace MyFirstMobileApp.ViewViewModels.Main.CollectionsContents.CollectionContents;

public partial class CollectionPageView : ContentPage
{
	public CollectionPageView()
	{
		InitializeComponent();
		BindingContext = new CollectionPageViewModel();
	}
}