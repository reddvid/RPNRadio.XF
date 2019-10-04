using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RPNRadio.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RPNRadio.Core
{
    public class AppStart : MvxAppStart
    {
        public AppStart(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {
        }

        protected override async Task NavigateToFirstViewModel(object hint = null)
        {
            await NavigationService.Navigate<RootViewModel>();
        }
    }
}
