﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;

namespace SLWModLoader
{
    public partial class NewModFrm : Form
    {
        public NewModFrm()
        {
            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys key)
        {
            if (ModifierKeys == Keys.None && key == Keys.Escape) { Close(); return true; }
            return base.ProcessDialogKey(key);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                foreach (Control control in Controls)
                {
                    if (control.GetType() == typeof(RadioButton) && (RadioButton)control != (RadioButton)sender)
                    {
                        ((RadioButton)control).Checked = false;
                    }
                }
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled = okBtn.Enabled = false;

            if (!radioButton3.Checked)
            {
                bool doinstall = false;

                if (radioButton1.Checked)
                {
                    OpenFileDialog ofd = new OpenFileDialog() { Title = "Choose a zip/7z/rar file that has a mod contained in it.", Filter = "*.zip/*.7z/*.rar | *.zip;" };
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (Directory.Exists(Application.StartupPath + "\\temp_install")) { Directory.Delete(Application.StartupPath + "\\temp_install", true); }
                        Directory.CreateDirectory(Application.StartupPath + "\\temp_install");

                        ZipFile.ExtractToDirectory(ofd.FileName, Application.StartupPath + "\\temp_install");
                        doinstall = true;
                    }
                }
                else if (radioButton2.Checked)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "The folder which contains the files for the mod that you would like to load in-game, these are typically extracted from a .zip/.7z/.rar archive." };
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        if (Directory.Exists(Application.StartupPath + "\\temp_install")) { Directory.Delete(Application.StartupPath + "\\temp_install", true); }

                        Mainfrm.DirectoryCopy(fbd.SelectedPath, Application.StartupPath + "\\temp_install", true);

                        doinstall = true;
                    }
                }

                if (doinstall)
                {
                    if (File.Exists(Application.StartupPath + "\\temp_install\\mod.ini"))
                    {
                        string dirname = Mainfrm.GetModINIinfo(File.ReadAllLines(Application.StartupPath + "\\temp_install\\mod.ini").ToList(), "Title");
                        foreach (char c in new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars()))
                        {
                            dirname = dirname.Replace(c.ToString(), "");
                        }
                        Directory.Move(Application.StartupPath + "\\temp_install", Mainfrm.gensdirectory + "\\mods\\" + dirname);
                        Mainfrm.RefreshModList();
                        return;
                    }
                    else
                    {
                        foreach (string dir in Directory.GetDirectories(Application.StartupPath + "\\temp_install", "*", SearchOption.AllDirectories))
                        {
                            if (File.Exists(dir + "\\mod.ini"))
                            {
                                string dirname = Mainfrm.GetModINIinfo(File.ReadAllLines(dir + "\\mod.ini").ToList(), "Title");
                                foreach (char c in new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars()))
                                {
                                    dirname = dirname.Replace(c.ToString(), "");
                                }
                                Directory.Move(dir, Mainfrm.gensdirectory + "\\mods\\" + dirname);
                                if (Directory.Exists(Application.StartupPath + "\\temp_install")) { Directory.Delete(Application.StartupPath + "\\temp_install", true); }
                                Mainfrm.RefreshModList();
                                return;
                            }
                        }

                        if (MessageBox.Show("Whoops! Sorry, but this doesn't appear to be a loadable mod! Would you like to try and install it anyway?", "Sonic Generations Mod Loader", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            if (Directory.GetDirectories(Application.StartupPath + "\\temp_install").Length > 0)
                            {
                                Directory.Move(Directory.GetDirectories(Application.StartupPath + "\\temp_install")[0], Mainfrm.gensdirectory + "\\mods\\" + new DirectoryInfo(Directory.GetDirectories(Application.StartupPath + "\\temp_install")[0]).Name);
                                if (Directory.Exists(Application.StartupPath + "\\temp_install")) { Directory.Delete(Application.StartupPath + "\\temp_install", true); }
                                Mainfrm.RefreshModList();
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                new DevNewModFrmTxt().ShowDialog();
            }

            Close();
        }

        private void NewModFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
