namespace MyFirstMobileApp.ViewViewModels.Main.StackLayoutContents.StackLayoutPageContents;

public partial class StackLayoutPageView : ContentPage
{
	public StackLayoutPageView()
	{
		InitializeComponent();
        BindingContext = new StackLayoutPageViewModel();
    }
}