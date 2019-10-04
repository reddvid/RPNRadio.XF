

using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCross.Forms.Platforms.Uap.Views;
using MvvmCross.Core;
using TipCalc.Forms.UI;

namespace TipCalc.Forms.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
     sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }
    }

    public abstract class TipCalcApp : MvxWindowsApplication<MvxFormsWindowsSetup<Core.App, FormsApp>, Core.App, FormsApp>
    {
    }
}
