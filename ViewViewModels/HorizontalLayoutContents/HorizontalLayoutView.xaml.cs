using MyFirstMobileApp.ViewViewModels.StackLayoutPageContents;

namespace MyFirstMobileApp.ViewViewModels.HorizontalLayoutContents;

public partial class HorizontalLayoutView : ContentPage
{
	public HorizontalLayoutView()
	{
		InitializeComponent();
        BindingContext = new HorizontalLayoutViewModel();
    }
}