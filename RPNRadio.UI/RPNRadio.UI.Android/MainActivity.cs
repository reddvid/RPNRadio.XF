using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.Forms.Platforms.Android.Core;
using RPNRadio.Core;
using MediaManager;
using MvvmCross;
using MvvmCross.Navigation;
using RPNRadio.Core.ViewModels;
using Xamarin.Forms;
using Plugin.CurrentActivity;
using Intent = global::Android.Content.Intent;
using Acr.UserDialogs;
using FFImageLoading.Forms.Platform;

namespace RPNRadio.UI.Droid
{
    [Activity(Label = "RPN News & Radio", Icon = "@drawable/ic_launcher", Theme = "@style/MainTheme.Launcher", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    //[IntentFilter(new[] { Intent.ActionSend, Intent.ActionSendMultiple, Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic }, DataMimeTypes = new[] { "video/*", "audio/*" }, Label = "RPN News & Radio")]
    public class MainActivity : MvxFormsAppCompatActivity<Setup, Core.App, FormsApp>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Forms.SetFlags("CollectionView_Experimental");

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            SetTheme(Resource.Style.MainTheme);
           
            UserDialogs.Init(this);
           
            base.OnCreate(savedInstanceState);
            CrossMediaManager.Current.Init(this);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            CachedImageRenderer.Init(true);
            CachedImageRenderer.InitImageViewHandler();
        }      

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}