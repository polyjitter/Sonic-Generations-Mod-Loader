using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLWModLoader
{
    public partial class DevNewModFrm : Form
    {
        private string name = "";

        public DevNewModFrm(string name)
        {
            InitializeComponent();
            this.name = name;
            listView1.Items[3].SubItems[1].Text = name;
            listView1.Items[6].SubItems[1].Text = $"{DateTime.Now.Date.Month.ToString()}/{DateTime.Now.Date.Day}/{DateTime.Now.Date.Year}";
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        protected override bool ProcessDialogKey(Keys key)
        {
            if (ModifierKeys == Keys.None && key == Keys.Delete)
            {
                rmvBtn.PerformClick();
            }
            return base.ProcessDialogKey(key);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                EditPropertyFrm editpfrm = new EditPropertyFrm(listView1.SelectedItems[0].SubItems[0].Text, (listView1.SelectedItems[0].SubItems.Count > 1) ? listView1.SelectedItems[0].SubItems[1].Text : "", (string)listView1.SelectedItems[0].Tag,listView1.SelectedItems[0].Group.Header,listView1.Groups);
                editpfrm.ShowDialog();

                if (!editpfrm.cancelled)
                {
                    listView1.SelectedItems[0].SubItems[0].Text = editpfrm.nameTxtbx.Text;
                    listView1.SelectedItems[0].Tag = editpfrm.typeCombobx.Text;

                    if (listView1.SelectedItems[0].SubItems.Count > 1) { listView1.SelectedItems[0].SubItems[1].Text = ((editpfrm.typeCombobx.Text != "Integer") ?editpfrm.valueCombobx.Text:editpfrm.valueNumericUpDown.Value.ToString()); }
                    else { listView1.SelectedItems[0].SubItems.Add(editpfrm.valueCombobx.Text); }

                    listView1.SelectedItems[0].ForeColor = (string.IsNullOrEmpty(editpfrm.valueCombobx.Text)) ? (editpfrm.nameTxtbx.Text == "IncludeDir0" || editpfrm.nameTxtbx.Text == "IncludeDirCount" || editpfrm.nameTxtbx.Text == "Title" || editpfrm.nameTxtbx.Text == "Description" || editpfrm.nameTxtbx.Text == "Author") ? Color.Red : Color.Orange : Color.Black;
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                    foreach (ListViewGroup group in listView1.Groups)
                    {
                        if (group.Header == editpfrm.groupCombobx.Text)
                        {
                            listView1.SelectedItems[0].Group = group;
                            return;
                        }
                    }

                    listView1.Groups.Add(new ListViewGroup(editpfrm.groupCombobx.Text));
                    listView1.SelectedItems[0].Group = listView1.Groups[listView1.Groups.Count - 1];
                }
            }
        }

        private void rmvBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(new ListViewItem("New Property", listView1.Groups[0]) { ForeColor = Color.Orange, Tag = "String" });
            listView1.Items[listView1.Items.Count - 1].Selected = true;
            editBtn.PerformClick();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            bool doclose = true; List<string> modini = new List<string>();
            DialogResult dr = DialogResult.None;

            foreach (ListViewGroup group in listView1.Groups)
            {
                if (!modini.Contains($"[{group.Header}]"))
                {
                    modini.Add($"[{group.Header}]");
                }

                foreach (ListViewItem property in listView1.Items)
                {
                    if (string.IsNullOrEmpty(property.Text) || property.SubItems.Count <= 1 || string.IsNullOrEmpty(property.SubItems[1].Text) || property.Name.Contains('=') || property.SubItems[1].Text.Contains('='))
                    {
                        if (dr == DialogResult.None)
                        {
                            dr = MessageBox.Show("One or more of the given properties seem to be empty/invalid! Would you like to keep them anyway?", "Sonic Generations Mod Loader", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
                            doclose = (dr != DialogResult.Cancel);
                            if (!doclose) { return; }
                        }
                        if (dr == DialogResult.No)
                        {
                            continue;
                        }
                    }

                    if (property.Group.Header == group.Header)
                    {
                        modini.Add($"{property.Text}={(((string)property.Tag != "Integer")?"\"":"")}{((property.SubItems.Count > 1)?property.SubItems[1].Text:"")}{(((string)property.Tag != "Integer")?"\"":"")}");
                    }
                }
                if (modini[modini.Count-1] == $"[{group.Header}]") { modini.RemoveAt(modini.Count-1); }
            }
            
            if (doclose)
            {
                Console.WriteLine(Mainfrm.gensdirectory + "\\mods\\" + name);
                string dirname = name;
                foreach (char c in new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars()))
                {
                    dirname = dirname.Replace(c.ToString(), "");
                }
                dirname = Mainfrm.gensdirectory + "\\mods\\" + dirname;

                if (Directory.Exists(dirname) && MessageBox.Show($"A mod already exists in the \"{name}\" folder. Would you like to delete it and replace it with this one?","Sonic Generations Mod Loader",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Directory.Delete(dirname,true);
                }
                else if (Directory.Exists(dirname)) { return; }
                Directory.CreateDirectory(dirname);
                File.WriteAllLines(dirname+"\\mod.ini", modini);

                Directory.CreateDirectory(dirname + "\\sound\\");

                Directory.CreateDirectory(dirname + "\\sound\\sng00_sys\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng01_ghz\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng02_cpz\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng03_ssz\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng04_sph\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng05_cte\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng06_ssh\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng07_csc\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng08_euc\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng09_pla\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng10_cnz\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng11_bms\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng12_bsd\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng13_bsl\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng14_bde\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng15_bpc\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng16_bne\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng17_blb\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng18_pam\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng19_jng\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng20_msn\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng21_etc\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng22_add\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng23_pam\\");
				
                Directory.CreateDirectory(dirname + "\\sound\\sng00_sys\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng01_ghz\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng02_cpz\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng03_ssz\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng04_sph\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng05_cte\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng06_ssh\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng07_csc\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng08_euc\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng09_pla\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng10_cnz\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng11_bms\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng12_bsd\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng13_bsl\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng14_bde\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng15_bpc\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng16_bne\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng17_blb\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng18_pam\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng19_jng\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng20_msn\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng21_etc\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng22_add\\synth\\");
                Directory.CreateDirectory(dirname + "\\sound\\sng23_pam\\synth\\");

                Directory.CreateDirectory(dirname + "\\disk\\");

                Directory.CreateDirectory(dirname + "\\disk\\bb\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb\\languages\\");

                Directory.CreateDirectory(dirname + "\\disk\\bb\\languages\\english\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\languages\\french\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\languages\\german\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\languages\\italian\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\languages\\japanese\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\languages\\spanish\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\");

                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\bde\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\blb\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\bne\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\bpc\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\cpz100\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\cpz200\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\cte100\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\cte102\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\cte200\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\ghz100\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\ghz103\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\ghz104\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\ghz200\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\sph100\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\sph101\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\sph200\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\ssz100\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\ssz103\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb\\packed\\ssz200\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\collection\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\hint\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\install\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\item\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\loading\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\loadinghint\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\reddog\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\languages\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\languages\\english\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\languages\\french\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\languages\\german\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\languages\\italian\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\languages\\japanese\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\languages\\spanish\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\voices\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\voices\\english\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\voices\\french\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\voices\\german\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\voices\\italian\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\voices\\japanese\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\voices\\spanish\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\bms\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\bsd\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\bsl\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\cnz100\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\csc100\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\csc200\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\euc100\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\euc200\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\euc204\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\evt041\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\evt121\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\fig000\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\pam000\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\pam001\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\pla100\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\pla200\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\pla204\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\pla205\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\ssh100\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\ssh101\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\ssh103\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\ssh200\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\ssh201\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb2\\packed\\ssh205\\");

                Directory.CreateDirectory(dirname + "\\disk\\bb3\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\languages\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\languages\\english\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\languages\\french\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\languages\\german\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\languages\\italian\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\languages\\japanese\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\languages\\spanish\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\voices\\");
				
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\voices\\english\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\voices\\french\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\voices\\german\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\voices\\italian\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\voices\\japanese\\");
                Directory.CreateDirectory(dirname + "\\disk\\bb3\\voices\\spanish\\");
				
                Process.Start(dirname + "\\");

                Mainfrm.RefreshModList();

                Close();
            }
        }
    }
}
