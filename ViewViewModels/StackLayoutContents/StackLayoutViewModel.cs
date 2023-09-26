using MyFirstMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.StackLayoutContents
{
    public class StackLayoutViewModel
    {
        public String StackLayoutViewTitle { get; set; } = TitleLayouts.StackLayoutViewTitle;
        public String StackLayoutViewButtonName { get; set; } = TitleLayouts.StackLayoutViewButtonName;
        public String VerticalLayoutButtonName { get; set; } = TitleLayouts.VerticalLayoutButtonName;
        public String HorizontalLayoutButtonName { get; set; } = TitleLayouts.HorizontalLayoutButtonName;
        public String AbsoluteLayoutButtonName { get; set; } = TitleLayouts.AbsoluteLayoutButtonName;

    }
}
