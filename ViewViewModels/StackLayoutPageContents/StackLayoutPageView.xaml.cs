namespace MyFirstMobileApp.ViewViewModels.StackLayoutPageContents;

public partial class StackLayoutPageView : ContentPage
{
	public StackLayoutPageView()
	{
		InitializeComponent();
        BindingContext = new StackLayoutPageViewModel();
    }
}