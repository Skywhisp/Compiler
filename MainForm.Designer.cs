using System.Windows.Forms;

namespace Compiler
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.CapsLockLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.languageKeyLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.outputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grammarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagnosisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.literatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.NewButton = new System.Windows.Forms.ToolStripButton();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelButton1 = new System.Windows.Forms.ToolStripButton();
            this.RepeatButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyButton = new System.Windows.Forms.ToolStripButton();
            this.CutButton = new System.Windows.Forms.ToolStripButton();
            this.InsertButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RunButton = new System.Windows.Forms.ToolStripButton();
            this.HelpButton1 = new System.Windows.Forms.ToolStripButton();
            this.AboutButton = new System.Windows.Forms.ToolStripButton();
            this.languageToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.russianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            resources.ApplyResources(this.mainSplitContainer, "mainSplitContainer");
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            resources.ApplyResources(this.mainSplitContainer.Panel1, "mainSplitContainer.Panel1");
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.statusStrip1);
            this.mainSplitContainer.Panel2.Controls.Add(this.outputRichTextBox);
            resources.ApplyResources(this.mainSplitContainer.Panel2, "mainSplitContainer.Panel2");
            this.mainSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.mainSplitContainer_SplitterMoved);
            this.mainSplitContainer.Resize += new System.EventHandler(this.mainSplitContainer_Resize);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CapsLockLabel,
            this.languageKeyLabel});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // CapsLockLabel
            // 
            this.CapsLockLabel.Name = "CapsLockLabel";
            resources.ApplyResources(this.CapsLockLabel, "CapsLockLabel");
            // 
            // languageKeyLabel
            // 
            this.languageKeyLabel.Name = "languageKeyLabel";
            resources.ApplyResources(this.languageKeyLabel, "languageKeyLabel");
            // 
            // outputRichTextBox
            // 
            resources.ApplyResources(this.outputRichTextBox, "outputRichTextBox");
            this.outputRichTextBox.Name = "outputRichTextBox";
            this.outputRichTextBox.ReadOnly = true;
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.textToolStripMenuItem,
            this.startupToolStripMenuItem,
            this.referenceToolStripMenuItem});
            resources.ApplyResources(this.mainMenu, "mainMenu");
            this.mainMenu.Name = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            resources.ApplyResources(this.createToolStripMenuItem, "createToolStripMenuItem");
            this.createToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelToolStripMenuItem,
            this.repeatToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.deleteToolStripMenuItem1,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            resources.ApplyResources(this.cancelToolStripMenuItem, "cancelToolStripMenuItem");
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.отменитьToolStripMenuItem_Click);
            // 
            // repeatToolStripMenuItem
            // 
            this.repeatToolStripMenuItem.Name = "repeatToolStripMenuItem";
            resources.ApplyResources(this.repeatToolStripMenuItem, "repeatToolStripMenuItem");
            this.repeatToolStripMenuItem.Click += new System.EventHandler(this.повторитьToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            resources.ApplyResources(this.cutToolStripMenuItem, "cutToolStripMenuItem");
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.вырезатьToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.копироватьToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            resources.ApplyResources(this.insertToolStripMenuItem, "insertToolStripMenuItem");
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.вставитьToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            resources.ApplyResources(this.deleteToolStripMenuItem1, "deleteToolStripMenuItem1");
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.выделитьВсеToolStripMenuItem_Click);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskToolStripMenuItem,
            this.grammarToolStripMenuItem,
            this.classificationToolStripMenuItem,
            this.analizeToolStripMenuItem,
            this.diagnosisToolStripMenuItem,
            this.testToolStripMenuItem,
            this.literatureToolStripMenuItem,
            this.sourceCodeToolStripMenuItem});
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            resources.ApplyResources(this.textToolStripMenuItem, "textToolStripMenuItem");
            // 
            // taskToolStripMenuItem
            // 
            this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            resources.ApplyResources(this.taskToolStripMenuItem, "taskToolStripMenuItem");
            // 
            // grammarToolStripMenuItem
            // 
            this.grammarToolStripMenuItem.Name = "grammarToolStripMenuItem";
            resources.ApplyResources(this.grammarToolStripMenuItem, "grammarToolStripMenuItem");
            // 
            // classificationToolStripMenuItem
            // 
            this.classificationToolStripMenuItem.Name = "classificationToolStripMenuItem";
            resources.ApplyResources(this.classificationToolStripMenuItem, "classificationToolStripMenuItem");
            // 
            // analizeToolStripMenuItem
            // 
            this.analizeToolStripMenuItem.Name = "analizeToolStripMenuItem";
            resources.ApplyResources(this.analizeToolStripMenuItem, "analizeToolStripMenuItem");
            // 
            // diagnosisToolStripMenuItem
            // 
            this.diagnosisToolStripMenuItem.Name = "diagnosisToolStripMenuItem";
            resources.ApplyResources(this.diagnosisToolStripMenuItem, "diagnosisToolStripMenuItem");
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            resources.ApplyResources(this.testToolStripMenuItem, "testToolStripMenuItem");
            // 
            // literatureToolStripMenuItem
            // 
            this.literatureToolStripMenuItem.Name = "literatureToolStripMenuItem";
            resources.ApplyResources(this.literatureToolStripMenuItem, "literatureToolStripMenuItem");
            // 
            // sourceCodeToolStripMenuItem
            // 
            this.sourceCodeToolStripMenuItem.Name = "sourceCodeToolStripMenuItem";
            resources.ApplyResources(this.sourceCodeToolStripMenuItem, "sourceCodeToolStripMenuItem");
            // 
            // startupToolStripMenuItem
            // 
            this.startupToolStripMenuItem.Name = "startupToolStripMenuItem";
            resources.ApplyResources(this.startupToolStripMenuItem, "startupToolStripMenuItem");
            // 
            // referenceToolStripMenuItem
            // 
            this.referenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.referenceToolStripMenuItem.Name = "referenceToolStripMenuItem";
            resources.ApplyResources(this.referenceToolStripMenuItem, "referenceToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewButton,
            this.OpenButton,
            this.SaveButton,
            this.toolStripSeparator1,
            this.CancelButton1,
            this.RepeatButton,
            this.toolStripSeparator3,
            this.CopyButton,
            this.CutButton,
            this.InsertButton,
            this.toolStripSeparator2,
            this.RunButton,
            this.HelpButton1,
            this.AboutButton,
            this.languageToolStripSplitButton});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // NewButton
            // 
            this.NewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewButton.Image = global::Compiler.Properties.Resources.add;
            resources.ApplyResources(this.NewButton, "NewButton");
            this.NewButton.Name = "NewButton";
            this.NewButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenButton.Image = global::Compiler.Properties.Resources.folder;
            resources.ApplyResources(this.OpenButton, "OpenButton");
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Image = global::Compiler.Properties.Resources.save;
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // CancelButton1
            // 
            this.CancelButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelButton1.Image = global::Compiler.Properties.Resources.left_arrow;
            this.CancelButton1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.CancelButton1.Name = "CancelButton1";
            resources.ApplyResources(this.CancelButton1, "CancelButton1");
            this.CancelButton1.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // RepeatButton
            // 
            this.RepeatButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RepeatButton.Image = global::Compiler.Properties.Resources.right_arrow;
            resources.ApplyResources(this.RepeatButton, "RepeatButton");
            this.RepeatButton.Name = "RepeatButton";
            this.RepeatButton.Click += new System.EventHandler(this.RepeatButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // CopyButton
            // 
            this.CopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopyButton.Image = global::Compiler.Properties.Resources.copy;
            resources.ApplyResources(this.CopyButton, "CopyButton");
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // CutButton
            // 
            this.CutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CutButton.Image = global::Compiler.Properties.Resources.cut;
            resources.ApplyResources(this.CutButton, "CutButton");
            this.CutButton.Name = "CutButton";
            this.CutButton.Click += new System.EventHandler(this.CutButton_Click);
            // 
            // InsertButton
            // 
            this.InsertButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InsertButton.Image = global::Compiler.Properties.Resources.paste;
            resources.ApplyResources(this.InsertButton, "InsertButton");
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // RunButton
            // 
            this.RunButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RunButton.Image = global::Compiler.Properties.Resources.run;
            resources.ApplyResources(this.RunButton, "RunButton");
            this.RunButton.Name = "RunButton";
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // HelpButton1
            // 
            this.HelpButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HelpButton1.Image = global::Compiler.Properties.Resources.question_mark;
            this.HelpButton1.Name = "HelpButton1";
            resources.ApplyResources(this.HelpButton1, "HelpButton1");
            this.HelpButton1.Click += new System.EventHandler(this.HelpButton1_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutButton.Image = global::Compiler.Properties.Resources.info;
            resources.ApplyResources(this.AboutButton, "AboutButton");
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // languageToolStripSplitButton
            // 
            this.languageToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.languageToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.russianToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripSplitButton.Image = global::Compiler.Properties.Resources.флаганглии;
            resources.ApplyResources(this.languageToolStripSplitButton, "languageToolStripSplitButton");
            this.languageToolStripSplitButton.Name = "languageToolStripSplitButton";
            // 
            // russianToolStripMenuItem
            // 
            this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
            resources.ApplyResources(this.russianToolStripMenuItem, "russianToolStripMenuItem");
            this.russianToolStripMenuItem.Click += new System.EventHandler(this.русскийToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.английскийToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grammarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagnosisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem literatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton NewButton;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton CancelButton1;
        private System.Windows.Forms.ToolStripButton RepeatButton;
        private System.Windows.Forms.ToolStripButton CopyButton;
        private System.Windows.Forms.ToolStripButton CutButton;
        private System.Windows.Forms.ToolStripButton InsertButton;
        //private System.Windows.Forms.RichTextBox inputRichTextBox;
        //private SynchronizedScrollRichTextBox inputRichTextBox;
        private System.Windows.Forms.RichTextBox outputRichTextBox;
        private System.Windows.Forms.ToolStripButton RunButton;
        private System.Windows.Forms.ToolStripButton HelpButton1;
        private System.Windows.Forms.ToolStripButton AboutButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.ToolStripSplitButton languageToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem russianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel CapsLockLabel;
        private ToolStripStatusLabel languageKeyLabel;
    }
}

