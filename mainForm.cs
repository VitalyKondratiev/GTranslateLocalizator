namespace GTranslateLocalizatorApp
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System;

    using GTranslateLocalizatorApp.Services.Contracts;
    using GTranslateLocalizatorApp.Services;
    using GTranslateLocalizatorApp.Structures;
    using System.ComponentModel;

    public partial class mainForm : Form
    {
        private ITranslationLibraryService appTranslatorService;
        private IFileXmlService appXmlService;

        private TranslationLibrary sourceLibrary;
        private List<TranslationLibrary> translatedLibraries = new();

        BackgroundWorker worker;

        bool scbState;
        bool lclbState;
        bool sfobState;

        public mainForm(ITranslationLibraryService appTranslatorService, IFileXmlService appXmlService)
        {
            InitializeComponent();

            this.appTranslatorService = appTranslatorService;
            this.appXmlService = appXmlService;

            SetLanguages();

            worker = new BackgroundWorker();
            worker.DoWork += generateTranslations;
            worker.RunWorkerCompleted += generateTranslationsCompleted;
            worker.ProgressChanged += generateTranslationsProgressChanged;
            worker.WorkerReportsProgress = true;
        }

        private void sourceFileOpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFileTextBox.Text = openFileDialog.FileName;
                sourceLibrary = appXmlService.LoadFromFile(openFileDialog.FileName, sourceComboBox.SelectedItem.ToString());
                generateButton.Enabled = true;
                translatedLibraries.Clear();
                ShowTranslations();
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            scbState = sourceComboBox.Enabled;
            lclbState = languagesCheckedListBox.Enabled;
            sfobState = sourceFileOpenButton.Enabled;
            sourceComboBox.Enabled = false;
            languagesCheckedListBox.Enabled = false;
            sourceFileOpenButton.Enabled = false;
            saveButton.Enabled = false;
            generateButton.Enabled = false;

            progressBar.Value = 0;
            worker.RunWorkerAsync();
        }

        private void generateTranslations(object? sender, EventArgs e)
        {
            translatedLibraries.Clear();
            int processsed = 0;
            foreach (string destinationLanguage in languagesCheckedListBox.CheckedItems)
            {
                translatedLibraries.Add(
                    appTranslatorService.TranslateLibrary(sourceLibrary, destinationLanguage)
                );
                processsed++;
                worker.ReportProgress((int)((float)processsed / languagesCheckedListBox.CheckedItems.Count * 100), translatedLibraries);
            }
        }
        private void generateTranslationsProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            DebugLog($"Translated {e.ProgressPercentage}%");
            progressBar.Value = e.ProgressPercentage;
            ShowTranslations();
        }

        private void generateTranslationsCompleted(object? sender, EventArgs e)
        {
            DebugLog("Generated succesfully!");
            ShowTranslations();

            var notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.Visible = true;
            notifyIcon.Text = "GTranslateLocalizator";
            notifyIcon.ShowBalloonTip(3000, "GTranslateLocalizator", "All translations generated!", ToolTipIcon.Info);

            sourceComboBox.Enabled = scbState;
            languagesCheckedListBox.Enabled = lclbState;
            sourceFileOpenButton.Enabled = sfobState;
            saveButton.Enabled = true;
            generateButton.Enabled = true;

            if (saveImmediateCheckBox.Checked)
            {
                saveButton_Click(worker, e);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string filePath = openFileDialog.FileName.Replace(openFileDialog.SafeFileName, "");
            foreach (TranslationLibrary translationLibrary in translatedLibraries)
            {
                string fileName = $"{filePath}\\{translationLibrary.Language}.xml";
                appXmlService.SaveToFile(translationLibrary, fileName);
            }
            DebugLog("Saving succesfully!");
        }

        private void SetLanguages()
        {
            foreach (string language in appTranslatorService.GetLanguageList())
            {
                sourceComboBox.Items.Add(language);
                languagesCheckedListBox.Items.Add(language);
            }
            sourceComboBox.SelectedItem = TranslationLibraryService.FromLanguageBase;
        }

        private void ShowTranslations()
        {
            translationsTabControl.TabPages.Clear();
            DrawTab(sourceLibrary);
            foreach (TranslationLibrary translationLibrary in translatedLibraries)
            {
                DrawTab(translationLibrary);
            }
        }

        private void DrawTab(TranslationLibrary translationLibrary)
        {
            var tabPage = new TabPage(translationLibrary.Language);
            var dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = new BindingSource(translationLibrary.Translations, null)
            };

            dataGridView.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn keyColumn = new DataGridViewTextBoxColumn();
            keyColumn.DataPropertyName = "Key";
            keyColumn.Width = 150;
            dataGridView.Columns.Add(keyColumn);
            DataGridViewTextBoxColumn valueColumn = new DataGridViewTextBoxColumn();
            valueColumn.DataPropertyName = "Value";
            valueColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns.Add(valueColumn);

            dataGridView.ColumnHeadersVisible = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.RowHeadersVisible = false;
            tabPage.Controls.Add(dataGridView);
            translationsTabControl.TabPages.Add(tabPage);
        }

        private void DebugLog(string logText)
        {
            logTextBox.Invoke((Action)(() =>
            {
                logTextBox.Text += $"{logText}\n";
            }));
        }

        private void logTextBox_TextChanged(object sender, EventArgs e)
        {
            logTextBox.SelectionStart = logTextBox.Text.Length;
            logTextBox.ScrollToCaret();
        }

        private void sourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (openFileDialog.FileName != string.Empty)
            {
                sourceLibrary.SetLanguage(sourceComboBox.SelectedItem.ToString());
                ShowTranslations();
            }
        }
    }
}