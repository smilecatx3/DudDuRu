using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace DudDuRu
{
    public partial class Form1 : Form
    {
        private Brush selectedBgBrush = new SolidBrush(Color.FromArgb(255, 255, 200));
        private DrawItemEventHandler drawItemEventHandler;
        private ScanResult duplicates;


        #region initialization
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            (actionToolStripMenuItem.DropDown as ToolStripDropDownMenu).ShowImageMargin = false;
            (helpToolStripMenuItem.DropDown as ToolStripDropDownMenu).ShowImageMargin = false;
            FormBorderStyle = FormBorderStyle.FixedSingle; // Disable resizable
            ActiveControl = menuStrip1; // Hide cursor

            drawItemEventHandler = new System.Windows.Forms.DrawItemEventHandler(listBox_details_DrawItem);
        }
        #endregion


        #region textBox_dir events
        private void textBox_dir_Click(object sender, EventArgs e)
        {
            textBox_folder.Text = (!backgroundWorker_scan.IsBusy && (folderBrowserDialog.ShowDialog() == DialogResult.OK)) ? 
                folderBrowserDialog.SelectedPath :
                textBox_folder.Text;
            ActiveControl = menuStrip1; // Hide cursor
        }

        private void textBox_folder_TextChanged(object sender, EventArgs e)
        {
             button_scan.Enabled = (textBox_folder.TextLength > 0);
        }
        #endregion


        #region scan button events
        private void button_scan_Click(object sender, EventArgs e)
        {
            button_scan.Enabled = false;
            listBox_details.DrawItem -= drawItemEventHandler;
            duplicates = null;

            listBox_overview.Items.Clear();
            listBox_details.Items.Clear();
            textBox_filePath.Clear();
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = "";
            
            backgroundWorker_scan.RunWorkerAsync();
        }

        private void backgroundWorker_scan_DoWork(object sender, DoWorkEventArgs e)
        {
            duplicates = new DuplicateFinder(sender as BackgroundWorker).FindDuplicateFiles(textBox_folder.Text);
        }

        private void backgroundWorker_scan_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = e.UserState.ToString();
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_scan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (duplicates.FileList.Count > 0) {
                MessageBox.Show(String.Format("Found {0} duplicates", duplicates.NumDuplicates), "Scan completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBox_details.DrawItem += drawItemEventHandler;
                listBox_overview.Items.Add("[OVERVIEW]");
                listBox_overview.Items.AddRange(duplicates.FileList.Keys.ToArray());
                listBox_overview.SelectedIndex = 0;
            } else {
                MessageBox.Show("No duplicates found", "Scan completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            toolStripStatusLabel1.Text = "Ready";
        }
        #endregion


        #region listbox_overview events
        private void listBox_overview_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_details.Items.Clear();
            textBox_filePath.Clear();
            if (listBox_overview.SelectedIndex == 0) {
                foreach (ISet<FileInfo> list in duplicates.FileList.Values)
                    listBox_details.Items.AddRange(list.ToArray());
            } else if (listBox_overview.SelectedIndex > 0) {
                listBox_details.Items.AddRange(duplicates.FileList[listBox_overview.SelectedItem as FileInfo].ToArray());
            }
        }

        private void listBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox_overview.IndexFromPoint(e.Location) == ListBox.NoMatches)
                listBox_overview.SelectedIndex = -1;
        }
        #endregion


        #region listbox_details events
        private void listBox_details_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool strikeout = duplicates.RemoveList[listBox_details.Items[e.Index] as FileInfo];
            e.DrawBackground();

            Brush fgBrush = strikeout ? Brushes.Gray : Brushes.SteelBlue;
            Brush bgBrush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? selectedBgBrush : Brushes.White;
            e.Graphics.FillRectangle(bgBrush, e.Bounds);
            e.Graphics.DrawString(
                listBox_details.Items[e.Index].ToString(),
                strikeout ? new Font(Control.DefaultFont, FontStyle.Strikeout) : Control.DefaultFont,
                fgBrush, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void listBox_details_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_details.SelectedIndex < 0) { 
                textBox_filePath.Clear();
                return;
            }
            string filePath = (listBox_details.SelectedItem as FileInfo).FullName;
            textBox_filePath.Text = filePath.Substring(textBox_folder.TextLength+1);
        }

        private void listBox_details_MouseDown(object sender, MouseEventArgs e)
        {
            int mousePoint = listBox_details.IndexFromPoint(e.Location);
            if (mousePoint == ListBox.NoMatches) {
                listBox_details.SelectedIndex = -1;
            } else if ((e.Button == MouseButtons.Right) && (listBox_details.SelectedItems.Count > 0)) {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        #endregion


        #region mouse right click events
        private void ToolStripMenuItem_Click_keep(object sender, EventArgs e)
        {
            setListBox_details(false);
        }

        private void ToolStripMenuItem_Click_remove(object sender, EventArgs e)
        {
            setListBox_details(true);
        }

        private void setListBox_details(bool keep)
        {
            foreach (Object item in listBox_details.SelectedItems)
                duplicates.RemoveList[item as FileInfo] = keep;
            listBox_details.Refresh();
        }

        private void ToolStripMenuItem_Click_open(object sender, EventArgs e)
        {
            foreach (Object item in listBox_details.SelectedItems)
                Process.Start("explorer.exe", "/select, " + (item as FileInfo).FullName);
        }
        #endregion


        #region menuitem events
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (duplicates==null || MessageBox.Show("Are you sure to move the files marked strikeout to recycle bin?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                MessageBox.Show("Please choose a directory and scan the files first.", "ACTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            listBox_details.DrawItem -= drawItemEventHandler;
            backgroundWorker_remove.RunWorkerAsync();
        }

        private void moveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Comming soon ^_^ (maybe)", "Move to", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void visitProjectSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/smilecatx3/DudDuRu");
        }
        #endregion


        #region backgroundWorker_remove events
        private void backgroundWorker_remove_DoWork(object sender, DoWorkEventArgs e)
        {
            IDictionary<FileInfo, ISet<FileInfo>> removedList = new Dictionary<FileInfo, ISet<FileInfo>>();

            // Remove files to recycle bin
            int total = duplicates.FileList.Values.Count;
            int progress = 0;
            foreach (KeyValuePair<FileInfo, ISet<FileInfo>> pair in duplicates.FileList) {
                foreach (FileInfo file in pair.Value) {
                    if (duplicates.RemoveList[file]) { 
                        FileSystem.DeleteFile(file.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        if (!removedList.ContainsKey(pair.Key))
                            removedList.Add(pair.Key, new HashSet<FileInfo>());
                        removedList[pair.Key].Add(file);
                    }
                }
                (sender as BackgroundWorker).ReportProgress((int)(++progress/total*100), "Removing file ...");
            }

            // Remove files from duplicates table
            foreach (KeyValuePair<FileInfo, ISet<FileInfo>> pair in removedList) {
                foreach (FileInfo file in pair.Value) {
                    duplicates.FileList[pair.Key].Remove(file);
                    duplicates.RemoveList.Remove(file);
                }
                if (duplicates.FileList[pair.Key].Count <= 1)
                    duplicates.FileList.Remove(pair.Key);
            }
        }

        private void backgroundWorker_remove_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            backgroundWorker_scan_ProgressChanged(sender, e);
        }

        private void backgroundWorker_remove_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Finished", "Remove File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listBox_overview.Items.Clear();
            listBox_details.Items.Clear();
            listBox_overview.Items.Add("[OVERVIEW]");
            listBox_overview.Items.AddRange(duplicates.FileList.Keys.ToArray());
            listBox_overview.SelectedIndex = 0;
            toolStripStatusLabel1.Text = "Ready";
            listBox_details.DrawItem += drawItemEventHandler;
        }
        #endregion
    }
}
