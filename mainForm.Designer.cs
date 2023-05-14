﻿namespace GTranslateLocalizatorApp
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
            logGroupBox = new GroupBox();
            translationsTabControl = new TabControl();
            sourceFileGroupBox.SuspendLayout();
            laguagesGroupBox.SuspendLayout();
            logGroupBox.SuspendLayout();
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
            sourceFileGroupBox.Text = "Source translations file";
            // 
            // sourceComboBox
            // 
            sourceComboBox.FormattingEnabled = true;
            sourceComboBox.Location = new Point(107, 51);
            sourceComboBox.Name = "sourceComboBox";
            sourceComboBox.Size = new Size(222, 23);
            sourceComboBox.TabIndex = 3;
            // 
            // sourceLanguageLabel
            // 
            sourceLanguageLabel.AutoSize = true;
            sourceLanguageLabel.Location = new Point(6, 54);
            sourceLanguageLabel.Name = "sourceLanguageLabel";
            sourceLanguageLabel.Size = new Size(95, 15);
            sourceLanguageLabel.TabIndex = 2;
            sourceLanguageLabel.Text = "Source language";
            // 
            // sourceFileOpenButton
            // 
            sourceFileOpenButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sourceFileOpenButton.Location = new Point(1069, 22);
            sourceFileOpenButton.Name = "sourceFileOpenButton";
            sourceFileOpenButton.Size = new Size(75, 23);
            sourceFileOpenButton.TabIndex = 1;
            sourceFileOpenButton.Text = "Open file...";
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
            languagesCheckedListBox.Size = new Size(155, 352);
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
            laguagesGroupBox.Text = "Destination languages";
            // 
            // generateButton
            // 
            generateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            generateButton.Enabled = false;
            generateButton.Location = new Point(12, 485);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(167, 28);
            generateButton.TabIndex = 3;
            generateButton.Text = "Generate translations";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveButton.Enabled = false;
            saveButton.Location = new Point(1007, 490);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(159, 23);
            saveButton.TabIndex = 4;
            saveButton.Text = "Save translatiions to files";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // logTextBox
            // 
            logTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logTextBox.Location = new Point(6, 22);
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.Size = new Size(969, 77);
            logTextBox.TabIndex = 5;
            logTextBox.Text = "";
            // 
            // logGroupBox
            // 
            logGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logGroupBox.Controls.Add(logTextBox);
            logGroupBox.Location = new Point(185, 378);
            logGroupBox.Name = "logGroupBox";
            logGroupBox.Size = new Size(981, 105);
            logGroupBox.TabIndex = 6;
            logGroupBox.TabStop = false;
            logGroupBox.Text = "Logs";
            // 
            // translationsTabControl
            // 
            translationsTabControl.Location = new Point(185, 103);
            translationsTabControl.Name = "translationsTabControl";
            translationsTabControl.SelectedIndex = 0;
            translationsTabControl.Size = new Size(981, 269);
            translationsTabControl.TabIndex = 7;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 525);
            Controls.Add(translationsTabControl);
            Controls.Add(logGroupBox);
            Controls.Add(saveButton);
            Controls.Add(generateButton);
            Controls.Add(laguagesGroupBox);
            Controls.Add(sourceFileGroupBox);
            Name = "mainForm";
            Text = "GTranslateLocalizator";
            sourceFileGroupBox.ResumeLayout(false);
            sourceFileGroupBox.PerformLayout();
            laguagesGroupBox.ResumeLayout(false);
            logGroupBox.ResumeLayout(false);
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
        private GroupBox logGroupBox;
        private TabControl translationsTabControl;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
    }
}