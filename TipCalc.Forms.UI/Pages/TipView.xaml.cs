using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalc.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipCalc.Forms.UI.Pages
{
    public partial class TipView : MvxContentPage<TipViewModel>
    {
        public TipView()
        {
            InitializeComponent();
        }
    }
}