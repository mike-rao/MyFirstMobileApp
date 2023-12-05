using MyFirstMobileApp.Models.Entities;

namespace MyFirstMobileApp.ViewViewModels.Main.CollectionsContents.AddEdit;

public partial class EditCollectionView : ContentPage
{
	public EditCollectionView(EntityCollectionPage supercell)
	{
		InitializeComponent();
		BindingContext = new EditCollectionViewModel();
		GameTitle.Text = supercell.NameofGame;
	}
}