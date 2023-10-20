﻿using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using MyFirstMobileApp.ViewViewModels.Main.Images;
using MyFirstMobileApp.ViewViewModels.StackLayoutContents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        //Pull button text from Model
        public String StackLayoutButton { get; set; } = TitleMain.StackLayoutButtonName;
        public String ImagesButton { get; set; } = TitleMain.ImagesButtonName;

        //Button Commands
        public ICommand OnLayoutsClicked { get; set; }
        public ICommand OnImagesClicked { get; set; }

        public MainViewModel()
        {
            Title = TitleMain.MainTitle;

            //Set Commands
            OnLayoutsClicked = new Command(OnLayoutsClickedAsync);
            OnImagesClicked = new Command(OnImagesClickedAsync);
        }

        //Navigation between pages
        private async void OnLayoutsClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StackLayoutView());
        }
        private async void OnImagesClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ImagesView());
        }
    }
}
