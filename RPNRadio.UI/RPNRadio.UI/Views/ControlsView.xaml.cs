using MvvmCross.Forms.Views;
using RPNRadio.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RPNRadio.UI.Views
{
    [DesignTimeVisible(false)]
    public partial class ControlsView : MvxContentView<ControlsViewModel>
    {
        public ControlsView()
        {
            InitializeComponent();
        }
    }
}