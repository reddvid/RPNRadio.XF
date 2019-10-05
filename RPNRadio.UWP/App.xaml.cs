using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCross.Forms.Platforms.Uap.Views;
using RPNRadio.Core;
using RPNRadio.UI;
using Xamarin.Forms;

namespace RPNRadio.UWP
{
    sealed partial class App
    {
        public App()
        {
            Forms.SetFlags("CollectionView_Experimental");
            // CrossMediaManager.Current.Init();
            InitializeComponent();
        }
    }

    public abstract class RPNRadioApp : MvxWindowsApplication<MvxFormsWindowsSetup<Core.App, FormsApp>, Core.App, FormsApp, MainPage>
    {
    }
}
