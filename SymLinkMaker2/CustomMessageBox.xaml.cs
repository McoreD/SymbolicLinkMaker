using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SymbolicLinkMaker
{
    public partial class CustomMessageBox : UserControl
    {
        public CustomMessageBox(string text, string button1 = "Ok", string button2 = "", string button3 = "")
        {
            InitializeComponent();
            Text.Text = text;
            Button1.Content = button1;

            if (!string.IsNullOrEmpty(button2))
            {
                Button2.Visibility = Visibility.Visible;
                Button2.Content = button2;
            }

            Button2.Content = button2;
            if (!string.IsNullOrEmpty(button3))
            {
                Button3.Visibility = Visibility.Visible;
                Button3.Content = button3;
            }
        }
    }
}