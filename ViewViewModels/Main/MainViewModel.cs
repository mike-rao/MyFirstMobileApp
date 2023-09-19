using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Title = TitleMain.MainTitle;
            Button = ButtonText.ButtonName;
        }
    }
}
