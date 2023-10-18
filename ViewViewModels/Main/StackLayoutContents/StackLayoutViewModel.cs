using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using MyFirstMobileApp.ViewViewModels.AbsoluteLayoutContents;
using MyFirstMobileApp.ViewViewModels.HorizontalLayoutContents;
using MyFirstMobileApp.ViewViewModels.Main.StackLayoutContents.FlexLayoutContent;
using MyFirstMobileApp.ViewViewModels.StackLayoutPageContents;
using MyFirstMobileApp.ViewViewModels.VerticalLayoutContents;
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
        public String FlexLayoutButtonName { get; set; } = TitleLayouts.FlexLayoutButtonName;

        //Button Commands
        public ICommand OnStackLayoutClicked { get; set; }
        public ICommand OnVerticalLayoutClicked { get; set; }
        public ICommand OnHorizontalLayoutClicked { get; set; }
        public ICommand OnAbsoluteLayoutClicked { get; set; }
        public ICommand OnFlexLayoutClicked { get; set; }

        //Constructor
        public StackLayoutViewModel()
        {
            Title = TitleLayouts.StackLayoutViewTitle;

            //Set Commands
            OnStackLayoutClicked = new Command(OnStackLayoutClickedAsync);
            OnVerticalLayoutClicked = new Command(OnVerticalLayoutClickedAsync);
            OnHorizontalLayoutClicked = new Command(OnHorizontalLayoutClickedAsync);
            OnAbsoluteLayoutClicked = new Command(OnAbsoluteLayoutClickedAsync);
            OnFlexLayoutClicked = new Command(OnFlexLayoutClickedAsync);
        }

        //Navigation between pages
        private async void OnStackLayoutClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StackLayoutPageView());
        }
        private async void OnVerticalLayoutClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VerticalLayoutView());
        }
        private async void OnHorizontalLayoutClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HorizontalLayoutView());
        }
        private async void OnAbsoluteLayoutClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AbsoluteLayoutView());
        }
        private async void OnFlexLayoutClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new FlexLayoutView());
        }
    }
}
