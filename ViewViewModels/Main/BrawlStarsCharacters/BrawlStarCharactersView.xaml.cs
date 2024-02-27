namespace MyFirstMobileApp.ViewViewModels.Main.BrawlStarsCharacters;

public partial class BrawlStarCharactersView : ContentPage
{
	public BrawlStarCharactersView()
	{
		InitializeComponent();
        BindingContext = new BrawlStarCharactersViewModel();
    }
}