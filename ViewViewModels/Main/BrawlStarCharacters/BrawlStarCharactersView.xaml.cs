namespace MyFirstMobileApp.ViewViewModels.Main.BrawlStarCharacters;

public partial class BrawlStarCharactersView : ContentPage
{
	public BrawlStarCharactersView()
	{
		InitializeComponent();
        BindingContext = new BrawlStarCharactersViewModel();
    }
}