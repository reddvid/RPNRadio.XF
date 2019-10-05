using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Forms.Platforms.Android.Core;

namespace RPNRadio.UI.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, FormsApp>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            //UserDialogs.Init(() => Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity);
            //ActionSheetConfig.DefaultAndroidStyleId = Android.Resource.Style.MainTheme_BottomSheet;
            //Mvx.IoCProvider.RegisterSingleton<HttpMessageHandler>(new AndroidClientHandler());
        }

        protected override IEnumerable<Assembly> AndroidViewAssemblies =>
            new List<Assembly>(base.AndroidViewAssemblies)
            {
                typeof(global::Android.Support.Design.Widget.BottomNavigationView).Assembly
            };
    }
}