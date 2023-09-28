using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.StackLayoutContents
{
    public class StackLayoutViewModel : BaseViewModel
    {
        //Pull button text from Model
        public String StackLayoutViewButtonName { get; set; } = TitleLayouts.StackLayoutViewButtonName;
        public String VerticalLayoutButtonName { get; set; } = TitleLayouts.VerticalLayoutButtonName;
        public String HorizontalLayoutButtonName { get; set; } = TitleLayouts.HorizontalLayoutButtonName;
        public String AbsoluteLayoutButtonName { get; set; } = TitleLayouts.AbsoluteLayoutButtonName;

        //Constructor
        public StackLayoutViewModel()
        {
            Title = TitleLayouts.StackLayoutViewTitle;
        }
    }
}
