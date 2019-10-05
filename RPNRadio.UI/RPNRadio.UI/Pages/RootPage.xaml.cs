using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using RPNRadio.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace RPNRadio.UI.Pages
{
    [DesignTimeVisible(false)]
    [MvxTabbedPagePresentation(TabbedPosition.Root, WrapInNavigationPage = true)]
    public partial class RootPage : MvxTabbedPage<RootViewModel>
    {
        public RootPage()
        {
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            InitializeComponent();
        }

        private bool _firstTime = true;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_firstTime)
            {
                ViewModel.ShowInitialViewModelsCommand.ExecuteAsync();
                _firstTime = false;
            }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
        }
    }
}