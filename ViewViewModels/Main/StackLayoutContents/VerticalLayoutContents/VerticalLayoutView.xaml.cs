using MyFirstMobileApp.ViewViewModels.Main.StackLayoutContents.StackLayoutPageContents;

namespace MyFirstMobileApp.ViewViewModels.Main.StackLayoutContents.VerticalLayoutContents;

public partial class VerticalLayoutView : ContentPage
{
	public VerticalLayoutView()
	{
		InitializeComponent();
        BindingContext = new VerticalLayoutViewModel();
    }
}