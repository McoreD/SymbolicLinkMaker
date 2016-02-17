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

namespace SymbolicLinkMaker.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop, true);
        }

        private void btnBrowseLinkDir_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnClearLinkName_Click(object sender, RoutedEventArgs e)
        {
            txtLinkName.Clear();
            txtLinkName.Focus();
        }

        private void btnBrowseTargetDir_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
        }

        private void FileExitCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void FileExitCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}