namespace MyFirstMobileApp.ViewViewModels.Main.BrawlStarCharacters;

public partial class BrawlStarCharactersMgmtView : ContentPage
{
	public BrawlStarCharactersMgmtView(BrawlStarCharacters brawlStarCharacters)
	{
		InitializeComponent();
        BindingContext = new BrawlStarCharactersMgmtViewModel(brawlStarCharacters);
    }
}