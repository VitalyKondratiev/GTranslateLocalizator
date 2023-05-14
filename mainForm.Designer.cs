namespace GTranslateLocalizatorApp
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sourceFileGroupBox = new GroupBox();
            sourceComboBox = new ComboBox();
            sourceLanguageLabel = new Label();
            sourceFileOpenButton = new Button();
            sourceFileTextBox = new TextBox();
            languagesCheckedListBox = new CheckedListBox();
            laguagesGroupBox = new GroupBox();
            generateButton = new Button();
            saveButton = new Button();
            logTextBox = new RichTextBox();
            openFileDialog = new OpenFileDialog();
            sourceFileGroupBox.SuspendLayout();
            laguagesGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // sourceFileGroupBox
            // 
            sourceFileGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sourceFileGroupBox.Controls.Add(sourceComboBox);
            sourceFileGroupBox.Controls.Add(sourceLanguageLabel);
            sourceFileGroupBox.Controls.Add(sourceFileOpenButton);
            sourceFileGroupBox.Controls.Add(sourceFileTextBox);
            sourceFileGroupBox.Location = new Point(12, 12);
            sourceFileGroupBox.Name = "sourceFileGroupBox";
            sourceFileGroupBox.Size = new Size(1154, 85);
            sourceFileGroupBox.TabIndex = 0;
            sourceFileGroupBox.TabStop = false;
            sourceFileGroupBox.Text = "Исходный файл переводов";
            // 
            // sourceComboBox
            // 
            sourceComboBox.FormattingEnabled = true;
            sourceComboBox.Location = new Point(84, 51);
            sourceComboBox.Name = "sourceComboBox";
            sourceComboBox.Size = new Size(222, 23);
            sourceComboBox.TabIndex = 3;
            // 
            // sourceLanguageLabel
            // 
            sourceLanguageLabel.AutoSize = true;
            sourceLanguageLabel.Location = new Point(6, 54);
            sourceLanguageLabel.Name = "sourceLanguageLabel";
            sourceLanguageLabel.Size = new Size(72, 15);
            sourceLanguageLabel.TabIndex = 2;
            sourceLanguageLabel.Text = "Язык файла";
            // 
            // sourceFileOpenButton
            // 
            sourceFileOpenButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sourceFileOpenButton.Location = new Point(1069, 22);
            sourceFileOpenButton.Name = "sourceFileOpenButton";
            sourceFileOpenButton.Size = new Size(75, 23);
            sourceFileOpenButton.TabIndex = 1;
            sourceFileOpenButton.Text = "Выбрать";
            sourceFileOpenButton.UseVisualStyleBackColor = true;
            sourceFileOpenButton.Click += sourceFileOpenButton_Click;
            // 
            // sourceFileTextBox
            // 
            sourceFileTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sourceFileTextBox.Location = new Point(6, 22);
            sourceFileTextBox.Name = "sourceFileTextBox";
            sourceFileTextBox.ReadOnly = true;
            sourceFileTextBox.Size = new Size(1057, 23);
            sourceFileTextBox.TabIndex = 0;
            // 
            // languagesCheckedListBox
            // 
            languagesCheckedListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            languagesCheckedListBox.FormattingEnabled = true;
            languagesCheckedListBox.IntegralHeight = false;
            languagesCheckedListBox.Location = new Point(6, 22);
            languagesCheckedListBox.Name = "languagesCheckedListBox";
            languagesCheckedListBox.Size = new Size(155, 347);
            languagesCheckedListBox.TabIndex = 1;
            languagesCheckedListBox.ItemCheck += languagesCheckedListBox_ItemCheck;
            // 
            // laguagesGroupBox
            // 
            laguagesGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            laguagesGroupBox.Controls.Add(languagesCheckedListBox);
            laguagesGroupBox.Location = new Point(12, 103);
            laguagesGroupBox.Name = "laguagesGroupBox";
            laguagesGroupBox.Size = new Size(167, 380);
            laguagesGroupBox.TabIndex = 2;
            laguagesGroupBox.TabStop = false;
            laguagesGroupBox.Text = "Выберите языки";
            // 
            // generateButton
            // 
            generateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            generateButton.Location = new Point(12, 485);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(167, 28);
            generateButton.TabIndex = 3;
            generateButton.Text = "Генерировать переводы";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveButton.Location = new Point(1091, 490);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 4;
            saveButton.Text = "Сохранить файлы";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // logTextBox
            // 
            logTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logTextBox.Location = new Point(185, 103);
            logTextBox.Name = "logTextBox";
            logTextBox.Size = new Size(977, 380);
            logTextBox.TabIndex = 5;
            logTextBox.Text = "";
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 525);
            Controls.Add(logTextBox);
            Controls.Add(saveButton);
            Controls.Add(generateButton);
            Controls.Add(laguagesGroupBox);
            Controls.Add(sourceFileGroupBox);
            Name = "mainForm";
            Text = "Генератор локализации";
            sourceFileGroupBox.ResumeLayout(false);
            sourceFileGroupBox.PerformLayout();
            laguagesGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox sourceFileGroupBox;
        private ComboBox sourceComboBox;
        private Label sourceLanguageLabel;
        private Button sourceFileOpenButton;
        private TextBox sourceFileTextBox;
        private CheckedListBox languagesCheckedListBox;
        private GroupBox laguagesGroupBox;
        private Button generateButton;
        private Button saveButton;
        private RichTextBox logTextBox;
        private OpenFileDialog openFileDialog;
        private TabControl tabControl1;
        private TabPage tabPage;
    }
}