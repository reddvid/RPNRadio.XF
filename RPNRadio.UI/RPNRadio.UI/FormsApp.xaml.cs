using RPNRadio.UI.Resources;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace RPNRadio.UI
{
    public partial class FormsApp : Application
    {
        public FormsApp()
        {
            InitializeComponent();

            var style = new Styles();
            style.MergedDictionaries.Add(new Light());
            Resources = style;

            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("android=aef4d841-d800-4ba1-aff4-f5b25d3e9299;" +
                   "uwp={Your UWP App secret here};" +
                   "ios={Your iOS App secret here}",
                   typeof(Analytics), typeof(Crashes));
        }

    }
}
