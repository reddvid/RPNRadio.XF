using RPNRadio.UI.Resources;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
