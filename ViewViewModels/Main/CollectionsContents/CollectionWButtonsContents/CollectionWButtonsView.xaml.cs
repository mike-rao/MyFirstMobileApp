namespace MyFirstMobileApp.ViewViewModels.Main.CollectionsContents.CollectionWButtonsContents;

public partial class CollectionWButtonsView : ContentPage
{
	public CollectionWButtonsView()
	{
        InitializeComponent();
        BindingContext = new CollectionWButtonsViewModel();
	}
}