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
    [MvxTabbedPagePresentation(WrapInNavigationPage = true, Icon = "outline_info_24", Title = "About")]
    public partial class AboutPage : MvxContentPage<AboutViewModel>
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            IconImageSource = ImageSource.FromFile("baseline_info_24");
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            IconImageSource = ImageSource.FromFile("outline_info_24");
            base.OnDisappearing();
        }

        private async void OpenTwitter_Tapped(object sender, EventArgs e)
        {
            await ViewModel.FollowCommand.ExecuteAsync();
        }

        private void Report_Tapped(object sender, EventArgs e)
        {
            ViewModel.ReportCommand.Execute();
        }
    }
}