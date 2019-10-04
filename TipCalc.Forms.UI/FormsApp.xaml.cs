using Xamarin.Forms;
using MvvmCross.Forms.Core;

namespace TipCalc.Forms.UI
{
    public partial class FormsApp : Application
    {
        public FormsApp()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }
    }
}