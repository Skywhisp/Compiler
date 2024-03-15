using Compiler.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Compiler.CustomTabPage;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Compiler
{
    public partial class MainForm : Form
    {
        #region Атрибуты формы
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        inputTabControl inputTab;
        #endregion

        

        //Базовая подсветка синтаксиса в окне редактирования.

        //Интерфейс с вкладками, позволяющий работать с разными модулями программы (для окна вывода результатов)

        //Отображение ошибок в окне вывода результатов в виде таблицы.

        public MainForm()
        {
            InitializeComponent();
            this.Text = AssemblyTitle;
            
            this.KeyPreview = true;

            this.InputLanguageChanged += (sender, e) =>
            {
                languageKeyLabel.Text = string.Format("Язык ввода: {0}", InputLanguage.CurrentInputLanguage.LayoutName);
            };
            CapsLockLabel.Text = string.Format("Клавиша CapsLock: " + (Control.IsKeyLocked(Keys.CapsLock) ? "Нажата" : "Не нажата"));
            languageKeyLabel.Text = string.Format("Язык ввода: {0}", InputLanguage.CurrentInputLanguage.LayoutName);

            inputTab = new inputTabControl();
            inputTab.Parent = this;
            mainSplitContainer.Panel1.Controls.Add(inputTab);
            inputTab.BringToFront();
            inputTab.GetTab().SelectedIndex = 0;
            (inputTab.GetTab().TabPages[0] as CustomTabPage).inputRichTextBox.TextChanged += new System.EventHandler(textChanged);
            inputTab.Size = new Size(mainSplitContainer.Width, mainSplitContainer.SplitterDistance);
            this.MainForm_Resize(null, null);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            mainSplitContainer.Size = new Size(this.Size.Width - 40, this.Height - 130);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if ((tabControl.TabPages[i] as CustomTabPage).isFileSaved)
                    continue;
                else
                {
                    tabControl.SelectedIndex = i;
                    if (showSaveMessageBox())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.language == "english")
            {
                this.languageToolStripSplitButton.Image = Resources.флаганглии;
                ChangeLanguage("en");
            }
            if (Properties.Settings.Default.language == "russian")
            {
                this.languageToolStripSplitButton.Image = Resources.флагрф;
                ChangeLanguage("ru-RU");
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            CapsLockLabel.Text = string.Format("Клавиша CapsLock: " + (Control.IsKeyLocked(Keys.CapsLock) ? "Нажата" : "Не нажата"));
        }

        private bool showSaveMessageBox()
        {
            const string message =
    "Изменения не сохранены\nВы хотите сохранить изменения?";
            const string caption = "Сохранение изменений";

            var result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNoCancel,
                                 MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
            }
            if(result == DialogResult.Yes)
            {
                saveFileDialog.ShowDialog();
            }
            if(result == DialogResult.Cancel)
            {
                return true;
            }
            return false;
        }

        private void createNewFile()
        {
            TabControl tabControl = inputTab.GetTab();
            if (!((tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).isFileSaved))
            {
                if (showSaveMessageBox())
                return;
            }
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.TextChanged += new System.EventHandler(textChanged);
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.Clear();
        }

        #region ToolStrip Buttons
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            createNewFile();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm(this);
            aboutForm.Show();
            this.Visible = false;
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (inputTab.tabControl1.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.Copy();
        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (inputTab.tabControl1.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.Cut();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (inputTab.tabControl1.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.Paste();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (inputTab.tabControl1.TabPages[inputTab.tabControl1.SelectedIndex] as CustomTabPage).Undo();
        }

        private void RepeatButton_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.Redo();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            if (!((tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).isFileSaved))
            {
                if(showSaveMessageBox())
                return;
            }

            openFileDialog.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            saveFileDialog.ShowDialog();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {

        }

        private void HelpButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Область редактирования представляет текстовый редактор. Команды меню «Файл» и «Правка» работают с содержимым этой области. Формат сохранения файлов – на усмотрение разработчика. Дополнительное задание: реализовать подсветку синтаксиса (выделение ключевых слов другим цветом или полужирным шрифтом).");
        }

        #endregion

        #region MenuStrip Buttons
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createNewFile();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            if (!((tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).isFileSaved))
            {
                if (showSaveMessageBox())
                    return;
            }

            openFileDialog.ShowDialog();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.SaveFile((tabControl.SelectedIndex.ToString()+".txt"), RichTextBoxStreamType.PlainText);
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).isFileSaved = true;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            
            for(int i = 0;i<tabControl.TabPages.Count;i++)
            {
                if((tabControl.TabPages[i] as CustomTabPage).isFileSaved)
                    continue;
                else
                {
                    tabControl.SelectedIndex = i;
                    if (showSaveMessageBox())
                        return;
                }
            }

            Application.Exit();
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.Undo();
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.Redo();

        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.Paste();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.SelectedText = "";
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.SelectAll();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm(this);
            aboutForm.Show();
            this.Visible = false;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Область редактирования представляет текстовый редактор. Команды меню «Файл» и «Правка» работают с содержимым этой области. Формат сохранения файлов – на усмотрение разработчика. Дополнительное задание: реализовать подсветку синтаксиса (выделение ключевых слов другим цветом или полужирным шрифтом).");
        }
        #endregion

        #region Работа с файлами
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            TabControl tabControl = inputTab.GetTab();
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).inputRichTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            (tabControl.TabPages[tabControl.SelectedIndex] as CustomTabPage).isFileSaved = true;
        }
        #endregion

        #region Resize functions
        private void resizeFunction()
        {
            if (inputTab != null)
            {
                inputTab.Size = new Size(mainSplitContainer.Width, mainSplitContainer.SplitterDistance);
            }
            outputRichTextBox.Size = new Size(mainSplitContainer.Width - 10, mainSplitContainer.Size.Height - mainSplitContainer.Panel1.Size.Height - 10 - statusStrip1.Height);
        }

        private void mainSplitContainer_Resize(object sender, EventArgs e)
        {
            resizeFunction();
        }

        private void mainSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            resizeFunction();
        }
        #endregion

        #region Смена языка

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
            foreach (ToolStripMenuItem item in this.MainMenuStrip.Items)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                resources.ApplyResources(item, item.Name, new CultureInfo(lang));
            }
            foreach (object item in this.toolStrip.Items)
            {
                if (!(item is ToolStripButton))
                    continue;
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                resources.ApplyResources(item, (item as ToolStripButton).Name, new CultureInfo(lang));
            }
        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            languageToolStripSplitButton.Image = Resources.флагрф;
            ChangeLanguage("ru-RU");
            Properties.Settings.Default.language = "russian";
            Properties.Settings.Default.Save();
        }

        private void английскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            languageToolStripSplitButton.Image = Resources.флаганглии;
            ChangeLanguage("en");
            Properties.Settings.Default.language = "english";
            Properties.Settings.Default.Save();
        }
        #endregion

        string lexemes = @"\b(const|int|val)";
        public void textChanged(object sender, EventArgs e)
        {
            ImprovedRichTextBox localTempTextBox = (sender as ImprovedRichTextBox);
            (localTempTextBox.Parent as CustomTabPage).isFileSaved = false;

            int st = localTempTextBox.SelectionStart;
            int end = localTempTextBox.SelectionLength;
            Color orig = Color.Black;

            MatchCollection lexeme_matches = Regex.Matches(localTempTextBox.Text, lexemes);

            localTempTextBox.SelectionStart = 0;
            localTempTextBox.SelectionLength = localTempTextBox.Text.Length;
            localTempTextBox.SelectionColor = orig;

            outputRichTextBox.Text = Lexer.lexText(localTempTextBox.Text);

            outputRichTextBox.Focus();
            foreach (Match match in lexeme_matches)
            {
                localTempTextBox.SelectionStart = match.Index;
                localTempTextBox.SelectionLength = match.Length;
                localTempTextBox.SelectionColor = Color.Green;
            }

            localTempTextBox.Focus();
            localTempTextBox.SelectionStart = st;
            localTempTextBox.SelectionLength = end;
            localTempTextBox.SelectionColor = orig;

            string[] splittedLines = localTempTextBox.Text.Split(new string[] { "\r", "\n", "\r\n" }
, StringSplitOptions.None);
            int linecount = splittedLines.Length;

            if (linecount != 0)
            {
                (localTempTextBox.Parent as CustomTabPage).linesRichTextBox.Clear();
                for (int i = 1; i < linecount + 1; i++)
                {
                    (localTempTextBox.Parent as CustomTabPage).linesRichTextBox.AppendText(Convert.ToString(i) + "\n");
                }
            }
        }
    }
}