using MyFirstMobileApp.Models.Entities;

namespace MyFirstMobileApp.ViewViewModels.Main.BrawlStarsCharacters;

public partial class BrawlStarCharactersMgmtView : ContentPage
{
	public BrawlStarCharactersMgmtView(BrawlStarCharacters brawlStarCharacters)
	{
		InitializeComponent();
        BindingContext = new BrawlStarCharactersMgmtViewModel(brawlStarCharacters);
    }
}