namespace MyFirstMobileApp.ViewViewModels.Main.ImagesContents;

public partial class ImagesView : ContentPage
{
	public ImagesView()
	{
		InitializeComponent();
		BindingContext = new ImagesViewModel();
	}
}