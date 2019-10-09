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
            //_titleRowHeight = titleRow.Height.Value;
            //Title = titleRow.Height.Value.ToString();
        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            var scrollVal = e.ScrollY;
            if (scrollVal >= 100)
            {
                //Set News Title to Page Title
                title.Text = ViewModel.Source.Title;
                subtitle.Text = ViewModel.Source.Author + " ⁃ " + ViewModel.Source.FormattedDate;
            }
            else if (scrollVal <= 10)
            {
                title.Text = subtitle.Text = string.Empty;
            }
        }
    }
}