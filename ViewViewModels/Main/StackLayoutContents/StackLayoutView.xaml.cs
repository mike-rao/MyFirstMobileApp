using MyFirstMobileApp.ViewViewModels.StackLayoutContents;

namespace MyFirstMobileApp.ViewViewModels.Main.StackLayoutContents;

public partial class StackLayoutView : ContentPage
{
	public StackLayoutView()
	{
        InitializeComponent();
        BindingContext = new StackLayoutViewModel();
    }
}