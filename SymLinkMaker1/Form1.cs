using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;

namespace SymbolicLinkMaker
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string linkDir = txtLinkDir.Text;
            string linkName = txtLinkName.Text;
            string targetDir = txtTargetDir.Text;
            
            //error handling
            if (linkDir == "")
            {
                MessageBox.Show("Please input a location where you want to make the Symbolic Link.",
                                "Symbolic Link Maker - invalid link",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtLinkDir.Focus();
                return;
            }

            if (linkName == "")
            {
                MessageBox.Show("Please input a name for the Symbolic Link.",
                                "Symbolic Link Maker - invalid link",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtLinkName.Focus();
                return;
            }

            if (targetDir == "")
            {
                MessageBox.Show("Please input a valid target for the Symbolic Link.",
                                "Symbolic Link Maker - invalid target",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtTargetDir.Focus();
                return;
            }

            try
            {
                DirectoryInfo diLinkTest = new DirectoryInfo(linkDir + "\\" + linkName);
            }
            catch
            {
                MessageBox.Show("Please input a Symbolic Link with a valid path.",
                                "Symbolic Link Maker - invalid link",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtLinkDir.Focus();
                return;
            }

            try
            {
                DirectoryInfo diTargetTest = new DirectoryInfo(targetDir);
            }
            catch
            {
                MessageBox.Show("Please input a target directory with a valid path",
                                "Symbolic Link Maker - invalid target",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtTargetDir.Focus();
                return;
            }

            //the real work starts here
            DirectoryInfo diLink = new DirectoryInfo(linkDir + "\\" + linkName);
            DirectoryInfo diTarget = new DirectoryInfo(targetDir);

                //lets see if there already exists a folder or symbolic link with that name
                if (diLink.Exists == true)
                {

                    //is it a symbolic link? 
                    FileAttributes fa = File.GetAttributes(diLink.FullName);
                    if ((fa & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint)
                    {
                        //ask user what to do? redirect the link or cancel operation
                        DialogResult result = MessageBox.Show("Symbolic Link with same name exists. \nShall I modify it to point to the new target?",
                                                                "Symbolic Link Maker - link already exists",
                                                                MessageBoxButtons.OKCancel,
                                                                MessageBoxIcon.Question);

                        //if redirect, delete the link
                        if (result == DialogResult.OK)
                        {
                            try
                            {
                                diLink.Delete();
                            }
                            catch
                            {
                                MessageBox.Show("Could not redirect the symbolic link!\nCancelling operations.",
                                                "Symbolic Link Maker - error redirecting",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
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

                            DialogResult result = MessageBox.Show("There is a folder with the same name as the Symbolic Link. \nShall I move all the files in it to Target folder\nand convert the folder into a Symbolic Link?\nNote: files with the same name will be overwritten without prompt.",
                                                                    "Symbolic Link Maker - move files",
                                                                    MessageBoxButtons.YesNoCancel,
                                                                    MessageBoxIcon.Question,
                                                                    MessageBoxDefaultButton.Button1);
                            if (result == DialogResult.Yes)
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
                                        MessageBox.Show("Could not create target directory!",
                                                        Properties.Resources.strErrorCaption,
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Error);
                                        return;
                                    }
                                }

                                //then copy the data in the link to target 
                                //Now Create all of the directories
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
                                    MessageBox.Show("Could not copy contents of the source to the target directory!\nBut the data is still safe in the source directory.",
                                                    Properties.Resources.strErrorCaption,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                                    return;
                                }

                                try
                                {
                                    diLink.Delete(true);
                                }
                                catch
                                {
                                    MessageBox.Show("Could not delete the source folder.\nBut the data is safe in the target folder.",
                                                    Properties.Resources.strErrorCaption,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                                    return;
                                }
                                
                            }
                            else if (result == DialogResult.No)
                            {
                                try
                                {
                                    diLink.Delete(true);
                                }
                                catch
                                {
                                    MessageBox.Show("Could not delete the source folder.",
                                                    Properties.Resources.strErrorCaption,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
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
                                MessageBox.Show("Could not delete the source folder.",
                                                Properties.Resources.strErrorCaption,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
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
                        MessageBox.Show("Could not create target directory!",
                                        Properties.Resources.strErrorCaption,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
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
                MessageBox.Show(Properties.Resources.strErrorCouldNotCreateLink,
                                Properties.Resources.strErrorCaption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Done.",
                            "Symbolic Link Maker",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnClearLinkName_Click(object sender, EventArgs e)
        {
            txtLinkName.Clear();
        }
        
        private void panelLink_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void panelLink_DragDrop(object sender, DragEventArgs e)
        {
            string[] folderToBeLinked = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (folderToBeLinked.Length == 1)
            {
                DirectoryInfo diFolderToBeLinked = new DirectoryInfo(folderToBeLinked[0]);

                if (checkLink.Checked == true)
                {
                    txtLinkDir.Text = diFolderToBeLinked.Parent.FullName;
                    txtLinkName.Text = diFolderToBeLinked.Name;
                }
                else
                {
                    txtLinkDir.Text = diFolderToBeLinked.FullName;
                    txtLinkName.Text = "";
                }
            }
        }

        private void panelTarget_DragDrop(object sender, DragEventArgs e)
        {
            string[] targetFolder = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (targetFolder.Length == 1)
            {
                DirectoryInfo diTargetFolder = new DirectoryInfo(targetFolder[0]);
                txtTargetDir.Text = diTargetFolder.FullName;
            }
        }

        private void panelTarget_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void btnBrowseLinkDir_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryInfo diLinkDir = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                if (checkLink.Checked == true)
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

        private void checkLink_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string linkDir = txtLinkDir.Text + "\\" + txtLinkName.Text;
                DirectoryInfo diLinkDir = new DirectoryInfo(linkDir);

                if (checkLink.Checked == true)
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
            catch
            {

            }
        }

        private void btnBrowseTargetDir_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryInfo diTargetDir = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                txtTargetDir.Text = diTargetDir.FullName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox1 box = new AboutBox1())
            {
                box.ShowDialog(this);
            }
        }
    }
}
