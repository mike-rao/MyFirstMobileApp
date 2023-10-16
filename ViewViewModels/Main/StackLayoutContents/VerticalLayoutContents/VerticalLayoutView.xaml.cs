using MyFirstMobileApp.ViewViewModels.StackLayoutPageContents;

namespace MyFirstMobileApp.ViewViewModels.VerticalLayoutContents;

public partial class VerticalLayoutView : ContentPage
{
	public VerticalLayoutView()
	{
		InitializeComponent();
        BindingContext = new VerticalLayoutViewModel();
    }
}