namespace GTranslateLocalizatorApp
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System;

    using GTranslateLocalizatorApp.Services.Contracts;
    using GTranslateLocalizatorApp.Services;
    using GTranslateLocalizatorApp.Structures;

    public partial class mainForm : Form
    {
        private ITranslationLibraryService appTranslatorService;
        private IFileXmlService appXmlService;

        private TranslationLibrary sourceLibrary;
        private List<TranslationLibrary> translatedLibraries = new();

        public mainForm(ITranslationLibraryService appTranslatorService, IFileXmlService appXmlService)
        {
            InitializeComponent();

            this.appTranslatorService = appTranslatorService;
            this.appXmlService = appXmlService;

            SetLanguages();
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
            bool scbState = sourceComboBox.Enabled;
            bool lclbState = languagesCheckedListBox.Enabled;
            bool sfobState = sourceFileOpenButton.Enabled;
            sourceComboBox.Enabled = false;
            languagesCheckedListBox.Enabled = false;
            sourceFileOpenButton.Enabled = false;
            saveButton.Enabled = false;
            generateButton.Enabled = false;

            translatedLibraries.Clear();
            foreach (string destinationLanguage in languagesCheckedListBox.CheckedItems)
            {
                translatedLibraries.Add(
                    appTranslatorService.TranslateLibrary(sourceLibrary, destinationLanguage)
                );
            }
            ShowTranslations();

            sourceComboBox.Enabled = scbState;
            languagesCheckedListBox.Enabled = lclbState;
            sourceFileOpenButton.Enabled = sfobState;
            saveButton.Enabled = true;
            generateButton.Enabled = true;
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
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
    }
}