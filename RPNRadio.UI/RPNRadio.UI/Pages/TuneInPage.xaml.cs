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
    [MvxTabbedPagePresentation(WrapInNavigationPage = true, Icon = "outline_library_music_24", Title = "Tune In")]
    public partial class TuneInPage : MvxContentPage<TuneInViewModel>
    {
        public TuneInPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            IconImageSource = ImageSource.FromFile("baseline_library_music_24");
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            IconImageSource = ImageSource.FromFile("outline_library_music_24");
            base.OnDisappearing();
        }

    }
}