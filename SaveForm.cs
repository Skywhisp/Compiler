using System;
using System.IO;
using System.Windows.Forms;

namespace Compiler
{
    public partial class SaveForm : Form
    {
        MainForm form1;
        string filePath1;

        public SaveForm(MainForm owner)
        {
            InitializeComponent();
            form1 = owner;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            filePath1 = form1.filePath;

            if (filePath1 != null)
                File.WriteAllText(filePath1, form1.richTextBox1.Text);
            else
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = "c:\\";
                    saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                    saveFileDialog.FilterIndex = 2;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        form1.filePath = saveFileDialog.FileName;
                        var fileStream = saveFileDialog.OpenFile();

                        using (StreamWriter writer = new StreamWriter(fileStream))
                        {
                            writer.Write(form1.richTextBox1.Text);
                        }
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void buttonNotSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
