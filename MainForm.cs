using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

namespace Compiler
{
    public partial class MainForm : Form
    {
        Stream fileStream;
        public string filePath;
        bool isEdited = false;

        public MainForm()
        {
            InitializeComponent();

            this.KeyPreview = true;

            this.InputLanguageChanged += (sender, e) =>
            {
                languageKeyLabel.Text = string.Format("Язык ввода: {0}", InputLanguage.CurrentInputLanguage.LayoutName);
            };
            CapsLockLabel.Text = string.Format("Клавиша CapsLock: " + (Control.IsKeyLocked(Keys.CapsLock) ? "Нажата" : "Не нажата"));
            languageKeyLabel.Text = string.Format("Язык ввода: {0}", InputLanguage.CurrentInputLanguage.LayoutName);

            this.MainForm_Resize(null, null);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isEdited) {}
            else
            {
                SaveForm saveForm = new SaveForm(this);

                saveForm.ShowDialog();

                if (saveForm.DialogResult == DialogResult.OK)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            mainSplitContainer.Size = new Size(this.Size.Width - 40, this.Height - 130);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            CapsLockLabel.Text = string.Format("Клавиша CapsLock: " + (Control.IsKeyLocked(Keys.CapsLock) ? "Нажата" : "Не нажата"));
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Text = "";
            }
            errorStripStatusLabel1.Text = "";
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var InfoForm = new InfoForm();
            InfoForm.Show();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
                richTextBox1.Copy();
            }
        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
                richTextBox1.Cut();
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void RepeatButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            richTextBox1.Text = fileContent;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    var fileStream = saveFileDialog.OpenFile();

                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write(richTextBox1.Text);
                    }
                }
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            try
            {
                string input = richTextBox1.Text;
                string result = PolizConverter.InfixToPostfix(input);

                richTextBox2.Clear();

                richTextBox2.AppendText(result);
            }
            catch (Exception ex)
            {
                richTextBox2.Clear();
                richTextBox2.AppendText($"Произошла ошибка: {ex.Message}");
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            var HelpForm = new HelpForm();
            HelpForm.Show();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Text = "";
            }
            errorStripStatusLabel1.Text = "";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            richTextBox1.Text = fileContent;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    var fileStream = saveFileDialog.OpenFile();

                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write(richTextBox1.Text);
                    }
                }
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    var fileStream = saveFileDialog.OpenFile();

                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write(richTextBox1.Text);
                    }
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormClosing -= MainForm_FormClosing;

            if (isEdited)
            {
                Close();
            }
            else
            {
                SaveForm saveForm = new SaveForm(this);

                saveForm.ShowDialog();

                if (saveForm.DialogResult == DialogResult.OK)
                {
                    Close();
                }
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
                richTextBox1.Cut();
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
                richTextBox1.Copy();
            }
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Text = "";
            }
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
            }
        }

        private void постановкаЗадачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string htmlFilePath = @"C:\Users\Vadim\Desktop\Compiler-CourseWork\Resources\htmls\task.html";
            
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = htmlFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при попытке открыть html документ: {ex.Message}");
            }
        }
        private void грамматикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string htmlFilePath = @"C:\Users\Vadim\Desktop\Compiler-CourseWork\Resources\htmls\Grammar.html";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = htmlFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при попытке открыть html документ: {ex.Message}");
            }
        }
        private void классификацияГрамматикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string htmlFilePath = @"C:\Users\Vadim\Desktop\Compiler-CourseWork\Resources\htmls\GrammarClassification.html";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = htmlFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при попытке открыть html документ: {ex.Message}");
            }
        }
        private void методАнализаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string htmlFilePath = @"C:\Users\Vadim\Desktop\Compiler-CourseWork\Resources\htmls\MethodOfAnalisys.html";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = htmlFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при попытке открыть html документ: {ex.Message}");
            }
        }
        private void диагностикаИНейтрализацияОшибокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string htmlFilePath = @"C:\Users\Vadim\Desktop\Compiler-CourseWork\Resources\htmls\DiagnosticsAndNeutralization.html";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = htmlFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при попытке открыть html документ: {ex.Message}");
            }
        }
        private void тестовыйПримерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string htmlFilePath = @"C:\Users\Vadim\Desktop\Compiler-CourseWork\Resources\htmls\Examples.html";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = htmlFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при попытке открыть html документ: {ex.Message}");
            }
        }
        private void списокЛитературыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string htmlFilePath = @"C:\Users\Vadim\Desktop\Compiler-CourseWork\Resources\htmls\Literature.html";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = htmlFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при попытке открыть html документ: {ex.Message}");
            }
        }
        private void исходныйКодПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start($"https://github.com/Skywhisp/CourseWork_Compiler");
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var InfoForm = new InfoForm();
            InfoForm.Show();
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var HelpForm = new HelpForm();
            HelpForm.Show();
        }
        private void пускToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resizeFunction()
        {
            richTextBox1.Size = new Size(mainSplitContainer.Width - 10, mainSplitContainer.Size.Height);
            richTextBox2.Size = new Size(mainSplitContainer.Width - 10, mainSplitContainer.Size.Height - mainSplitContainer.Panel1.Size.Height - 10 - statusStrip1.Height);
        }

        private void mainSplitContainer_Resize(object sender, EventArgs e)
        {
            resizeFunction();
        }

        private void mainSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            resizeFunction();
        }
    }
}