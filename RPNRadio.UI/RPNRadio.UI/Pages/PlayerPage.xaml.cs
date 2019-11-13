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
using Xamarin.Forms.Xaml;

namespace RPNRadio.UI.Pages
{
    [DesignTimeVisible(false)]
    public partial class PlayerPage : MvxContentPage<PlayerViewModel>
    {
        public PlayerPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            phoneView.IsVisible = tabletView.IsVisible = false;

            if (Device.Idiom == TargetIdiom.Phone)
            {
                phoneView.IsVisible = true;
            }
            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                tabletView.IsVisible = true;
            }

            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

    }
}