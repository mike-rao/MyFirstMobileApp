namespace MyFirstMobileApp.ViewViewModels.Main.CollectionsContents.AddEdit;

public partial class AddCollectionView : ContentPage
{
	public AddCollectionView()
	{
		InitializeComponent();
		BindingContext = new AddCollectionViewModel();
	}
}