using Gat.Controls;
using HelpersLib;
using MaterialDesignThemes.Wpf;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        #region Methods

        private string BrowseFolder(string title = "Browse folder")
        {
            OpenDialogView openDialog = new OpenDialogView();
            OpenDialogViewModel vm = (OpenDialogViewModel)openDialog.DataContext;
            vm.IsDirectoryChooser = true;
            vm.Caption = "Browse for the link directory";
            vm.DateFormat = OpenDialogViewModelBase.ISO8601_DateFormat;
            vm.OpenText = "Select folder";
            vm.SelectFolder = true;
            vm.Owner = this;
            vm.StartupLocation = WindowStartupLocation.CenterScreen;

            if (vm.Show() == true)
            {
                return string.IsNullOrEmpty(vm.SelectedFilePath) ? vm.SelectedFolder.Path : vm.SelectedFilePath;
            }

            return null;
        }

        public async void CreateSymLink(string linkDir, string linkName, string targetDir)
        {
            // TODO: MessageBoxStyle.Error etc.
            // error handling
            if (string.IsNullOrEmpty(linkDir))
            {
                CustomMessageBox messageBox = new CustomMessageBox("Please input a location where you want to make the Symbolic Link.");
                await DialogHost.Show(messageBox);
                txtLinkDir.Focus();
                return;
            }

            if (string.IsNullOrEmpty(linkName))
            {
                CustomMessageBox messageBox = new CustomMessageBox("Please input a name for the Symbolic Link.");
                await DialogHost.Show(messageBox);
                txtLinkName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(targetDir))
            {
                CustomMessageBox messageBox = new CustomMessageBox("Please input a valid target for the Symbolic Link..");
                await DialogHost.Show(messageBox);
                txtTargetDir.Focus();
                return;
            }

            string srcDirPath = Path.Combine(linkDir, linkName);
            if (!Directory.Exists(srcDirPath))
            {
                CustomMessageBox messageBox = new CustomMessageBox($"Would you like to create {srcDirPath}?", "Yes", "No");
                string result = await DialogHost.Show(messageBox) as string;
                if (result.Equals("1", StringComparison.InvariantCultureIgnoreCase))
                {
                    Helpers.CreateDirectoryIfNotExist(srcDirPath);
                }
                else
                {
                    return;
                }
            }

            if (!Directory.Exists(targetDir))
            {
                CustomMessageBox messageBox = new CustomMessageBox("Please input a target directory with a valid path.");
                await DialogHost.Show(messageBox);
                txtTargetDir.Focus();
                return;
            }

            //the real work starts here
            DirectoryInfo diLink = new DirectoryInfo(Path.Combine(linkDir, linkName));
            DirectoryInfo diTarget = new DirectoryInfo(targetDir);

            //lets see if there already exists a folder or symbolic link with that name
            if (diLink.Exists == true)
            {
                //is it a symbolic link?
                FileAttributes fa = File.GetAttributes(diLink.FullName);
                if ((fa & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint)
                {
                    //ask user what to do? redirect the link or cancel operation
                    CustomMessageBox messageBox = new CustomMessageBox("Symbolic Link with same name exists. \nShall I modify it to point to the new target?", "Ok", "Cancel");
                    string result = await DialogHost.Show(messageBox) as string;

                    //if redirect, delete the link
                    if (result.Equals("1", StringComparison.InvariantCultureIgnoreCase))
                    {
                        try
                        {
                            diLink.Delete();
                        }
                        catch
                        {
                            CustomMessageBox messageBox2 = new CustomMessageBox("Could not redirect the symbolic link!\nCancelling operations.");
                            await DialogHost.Show(messageBox2);
                            return;
                        }
                    }
                    else
                    {
                        txtLinkName.Focus();
                        return;
                    }
                }
                else
                {
                    //if it is a folder
                    //check if there are contents in it
                    FileInfo[] fiTest = diLink.GetFiles();
                    DirectoryInfo[] diTest = diLink.GetDirectories();

                    //if it is not empty
                    if (fiTest.Length > 0 || diTest.Length > 0)
                    {
                        CustomMessageBox msgBox = new CustomMessageBox("There is a folder with the same name as the symbolic Link. \nShall I move all the files in it to target folder\nand convert the folder into a symbolic Link?\nNote: files with the same name will be overwritten without prompt.", "Yes", "No", "Cancel");
                        string result = await DialogHost.Show(msgBox) as string;

                        if (result.Equals("1", StringComparison.InvariantCultureIgnoreCase))
                        {
                            //check if the target folder exists

                            if (diTarget.Exists == false)
                            {
                                //if not, create
                                try
                                {
                                    diTarget.Create();
                                }
                                catch
                                {
                                    CustomMessageBox dlg1 = new CustomMessageBox("Could not create target directory!");
                                    await DialogHost.Show(dlg1);
                                    return;
                                }
                            }

                            //then copy the data in the link to target
                            //Now Create all of the directories
                            await Task.Run(async () =>
                             {
                                 try
                                 {
                                     foreach (string dirPath in Directory.GetDirectories(diLink.FullName, "*", SearchOption.AllDirectories))
                                     {
                                         Directory.CreateDirectory(dirPath.Replace(diLink.FullName, diTarget.FullName));
                                     }

                                     //Copy all the files
                                     foreach (string newPath in Directory.GetFiles(diLink.FullName, "*.*", SearchOption.AllDirectories))
                                     {
                                         File.Copy(newPath, newPath.Replace(diLink.FullName, diTarget.FullName), true);
                                     }
                                 }
                                 catch
                                 {
                                     CustomMessageBox dlg2 = new CustomMessageBox("Could not copy contents of the source to the target directory!\nBut the data is still safe in the source directory.");
                                     await DialogHost.Show(dlg2);
                                     return;
                                 }
                             });

                            try
                            {
                                diLink.Delete(true);
                            }
                            catch
                            {
                                CustomMessageBox dlg3 = new CustomMessageBox("Could not delete the source folder.\nBut the data is safe in the target folder.");
                                await DialogHost.Show(dlg3);
                                return;
                            }
                        }
                        else if (result.Equals("2", StringComparison.InvariantCultureIgnoreCase))
                        {
                            try
                            {
                                diLink.Attributes = FileAttributes.Normal;
                                diLink.Delete(true);
                            }
                            catch
                            {
                                CustomMessageBox dlg4 = new CustomMessageBox($"Could not delete the source folder\n{diLink.FullName}");
                                await DialogHost.Show(dlg4);
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            diLink.Delete(true);
                        }
                        catch
                        {
                            CustomMessageBox dlg2 = new CustomMessageBox("Could not delete the source folder.");
                            await DialogHost.Show(dlg2);
                            return;
                        }
                    }
                }
            }

            if (diTarget.Exists == false)
            {
                //if not, create
                try
                {
                    diTarget.Create();
                }
                catch
                {
                    CustomMessageBox dlg1 = new CustomMessageBox("Could not create target directory!");
                    await DialogHost.Show(dlg1);
                    return;
                }
            }

            //create the process info
            string args = "/c mklink /d \"" + diLink.FullName + "\" \"" + diTarget.FullName + "\"";
            ProcessStartInfo pso = new ProcessStartInfo("cmd.exe", args);
            //pso.Verb = "runas";

            try
            {
                //create the symbolic link
                Process.Start(pso);
            }
            catch
            {
                CustomMessageBox dlg2 = new CustomMessageBox("Could not create symbolic link!");
                await DialogHost.Show(dlg2);
                return;
            }

            CustomMessageBox dlg = new CustomMessageBox("Done!");
            await DialogHost.Show(dlg);
            return;
        }

        #endregion Methods

        #region Main Menu

        private void miHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow window = new AboutWindow();
            window.Show();
        }

        private void FileExitCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void FileExitCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        #endregion Main Menu

        #region Buttons

        private void btnBrowseLinkDir_Click(object sender, RoutedEventArgs e)
        {
            string dirPath = BrowseFolder();
            if (!string.IsNullOrEmpty(dirPath))
            {
                {
                    DirectoryInfo diLinkDir = new DirectoryInfo(dirPath);
                    if (chkLink.IsChecked == true)
                    {
                        txtLinkDir.Text = diLinkDir.Parent.FullName;
                        txtLinkName.Text = diLinkDir.Name;
                    }
                    else
                    {
                        txtLinkDir.Text = diLinkDir.FullName;
                        txtLinkName.Text = "";
                    }
                }
            }
        }

        private void btnClearLinkName_Click(object sender, RoutedEventArgs e)
        {
            txtLinkName.Clear();
            txtLinkName.Focus();
        }

        private void btnBrowseTargetDir_Click(object sender, RoutedEventArgs e)
        {
            string dirPath = BrowseFolder();
            if (!string.IsNullOrEmpty(dirPath))
            {
                DirectoryInfo diTargetDir = new DirectoryInfo(dirPath);
                txtTargetDir.Text = diTargetDir.FullName;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateSymLink(txtLinkDir.Text, txtLinkName.Text, txtTargetDir.Text);
        }

        #endregion Buttons
    }
}