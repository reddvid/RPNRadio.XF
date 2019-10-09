using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using RPNRadio.UI.Droid.Renderers;
using RPNRadio.Core.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ColoredTableView), typeof(ColoredTableViewRenderer))]
namespace RPNRadio.UI.Droid.Renderers
{
    public class ColoredTableViewRenderer : TableViewRenderer
    {
        public ColoredTableViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;

            var listView = Control as global::Android.Widget.ListView;
            var coloredTableView = (ColoredTableView)Element;
            listView.Divider = new ColorDrawable(coloredTableView.SeparatorColor.ToAndroid());
            listView.DividerHeight = 3;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "SeparatorColor")
            {
                var listView = Control as global::Android.Widget.ListView;
                var coloredTableView = (ColoredTableView)Element;
                listView.Divider = new ColorDrawable(coloredTableView.SeparatorColor.ToAndroid());
            }
        }
    }
}
