using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RPNRadio.UI.Droid.Renderers;
using RPNRadio.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobRenderer))]
namespace RPNRadio.UI.Droid.Renderers
{
    public class AdMobRenderer : ViewRenderer
    {
        public AdMobRenderer(Context context) : base(context)
        {

        }

        private int GetSmartBannerDpHeight()
        {
            var dpHeight = Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density;

            if (dpHeight <= 400) return 32;
            if (dpHeight > 400 && dpHeight <= 720) return 50;
            return 90;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var ad = new AdView(Context)
                {
                    AdSize = AdSize.SmartBanner,
                    AdUnitId = "ca-app-pub-2042503086093877/8643207351" //"ca -app-pub-5402259232463002/8763752587" //"ca -app-pub-3940256099942544/6300978111" //"ca-app-pub-5402259232463002/8763752587"
                };

                var requestbuilder = new AdRequest.Builder();


                ad.LoadAd(requestbuilder.Build());
                e.NewElement.HeightRequest = GetSmartBannerDpHeight();


                SetNativeControl(ad);
            }
        }
    }


}