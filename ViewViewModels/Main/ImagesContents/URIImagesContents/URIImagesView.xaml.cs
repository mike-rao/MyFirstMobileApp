namespace MyFirstMobileApp.ViewViewModels.Main.ImagesContents.URIImagesContents;

public partial class URIImagesView : ContentPage
{
	public URIImagesView()
	{
		InitializeComponent();
		BindingContext = new URIImagesViewModel();
	}
}