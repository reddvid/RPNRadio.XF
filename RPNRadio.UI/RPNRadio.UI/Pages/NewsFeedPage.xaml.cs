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
    [MvxTabbedPagePresentation(WrapInNavigationPage = true, Icon = "outline_ballot_24", Title = "News Feed")]
    public partial class NewsFeedPage : MvxContentPage<NewsFeedViewModel>
    {
        public NewsFeedPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            IconImageSource = ImageSource.FromFile("baseline_ballot_24");
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            IconImageSource = ImageSource.FromFile("outline_ballot_24");
            base.OnDisappearing();
        }

    }
}