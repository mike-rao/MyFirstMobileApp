using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using MyFirstMobileApp.ViewViewModels.StackLayoutPageContents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.StackLayoutContents
{
    public class StackLayoutViewModel : BaseViewModel
    {
        //Pull button text from Model
        public String StackLayoutViewButtonName { get; set; } = TitleLayouts.StackLayoutViewButtonName;
        public String VerticalLayoutButtonName { get; set; } = TitleLayouts.VerticalLayoutButtonName;
        public String HorizontalLayoutButtonName { get; set; } = TitleLayouts.HorizontalLayoutButtonName;
        public String AbsoluteLayoutButtonName { get; set; } = TitleLayouts.AbsoluteLayoutButtonName;

        //Button Commands
        public ICommand OnStackLayoutClicked { get; set; }

        //Constructor
        public StackLayoutViewModel()
        {
            Title = TitleLayouts.StackLayoutViewTitle;

            //Set Commands
            OnStackLayoutClicked = new Command(OnStackLayoutClickedAsync);
        }

        //Navigation between pages
        private async void OnStackLayoutClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StackLayoutPageView());
        }
    }
}
