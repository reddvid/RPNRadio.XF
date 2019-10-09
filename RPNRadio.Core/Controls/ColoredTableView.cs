using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RPNRadio.Core.Controls
{
    public class ColoredTableView : TableView
    {
        public ColoredTableView()
        {

        }

        public ColoredTableView(TableRoot root) : base(root)
        {

        }

        public static BindableProperty SeparatorColorProperty = BindableProperty.Create(nameof(SeparatorColor), typeof(Color), typeof(ColoredTableView), Color.White);
        public Color SeparatorColor
        {
            get => (Color)GetValue(SeparatorColorProperty);
            set => SetValue(SeparatorColorProperty, value);
        }
    }
}
