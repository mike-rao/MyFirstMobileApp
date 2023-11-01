namespace MyFirstMobileApp.ViewViewModels.Main.ImagesContents.EmbeddedContents;

public partial class EmbeddedView : ContentPage
{
	public EmbeddedView()
	{
		InitializeComponent();
		BindingContext = new EmbeddedViewModel();
	}
}