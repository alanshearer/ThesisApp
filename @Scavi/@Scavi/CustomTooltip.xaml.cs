using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace _Scavi
{
    public partial class CustomTooltip : UserControl
    {
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public CustomTooltip()
        {
            InitializeComponent();
            Loaded += UCCustomToolTip_Loaded;
        }

        void UCCustomToolTip_Loaded(object sender, RoutedEventArgs e)
        {
            Lbltext.Text = Description;
        }
        public void FillDescription()
        {
            Lbltext.Text = Description;

        }

        private void imgmarker_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            if (imgpath.Opacity == 0)
            {
                imgpath.Opacity = 1;
                imgborder.Opacity = 1;
            }
            else
            {
                imgpath.Opacity = 0;
                imgborder.Opacity = 0;
            }
        }
    }
}
