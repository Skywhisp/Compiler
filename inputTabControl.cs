using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Compiler
{
    public partial class inputTabControl : UserControl
    {

        public inputTabControl()
        {
            InitializeComponent();
            this.addTabPage();
            this.addTabPage();
        }

        public TabControl GetTab()
        {
            return tabControl1 as TabControl;
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == tabControl1.TabCount-1)
            {
                addTabPage();
            }

            

        }

        private void addTabPage()
        {
            tabControl1.TabPages.Add(new CustomTabPage(tabControl1.TabPages.Count));
            tabControl1.TabPages[tabControl1.TabPages.Count - 1].Size = tabControl1.Size;
        }

        private void richTextBox2_ControlAdded(object sender, ControlEventArgs e)
        {
            MessageBox.Show("Added");
        }

        private void tabControl1_Resize(object sender, EventArgs e)
        {

        }

        private void inputTabControl_Resize(object sender, EventArgs e)
        {
            tabControl1.Size = this.Size;
        }

        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tabControl1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tabControl1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string filePath = files[0];
                string fileContent = File.ReadAllText(filePath); ;
                (tabControl1.TabPages[tabControl1.SelectedIndex] as CustomTabPage).inputRichTextBox.Text = fileContent;
            }
        }
    }
}
