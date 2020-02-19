using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;
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
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class ReadingPage : MvxContentPage<ReadingViewModel>
    {
        private double _titleRowHeight = 0;

        public ReadingPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
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

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            var scrollVal = e.ScrollY;
            title.Text = ViewModel.Source.Title;
            subtitle.Text = ViewModel.Source.Author + " ⁃ " + ViewModel.Source.FormattedDate;

            title.Opacity = subtitle.Opacity = e.ScrollY / 100;
        }

    }
}