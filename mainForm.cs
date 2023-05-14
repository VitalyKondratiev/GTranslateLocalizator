namespace GTranslateLocalizatorApp
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Xml;
    using System;

    using GTranslate;
    using GTranslate.Translators;
    using GTranslate.Results;

    struct TranslationLibrary
    {
        public string Language;
        public Dictionary<string, string> Translations;

        public TranslationLibrary(string language, Dictionary<string, string> translations)
        {
            Language = language;
            Translations = translations;
        }
    }

    public partial class mainForm : Form
    {
        private TranslationLibrary sourceLibrary;
        private List<TranslationLibrary> translatedLibraries = new();

        private List<string> translateLanguages = new();

        private const string FROM_LANGUAGE_BASE = "Russian";

        public mainForm()
        {
            InitializeComponent();
            SetLanguages();
        }

        private void sourceFileOpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFileTextBox.Text = openFileDialog.FileName;
                XmlDocument doc = new XmlDocument();
                doc.Load(openFileDialog.FileName);
                sourceLibrary = InitFile(doc);
                generateButton.Enabled = true;
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            foreach (string destinationLanguage in translateLanguages)
            {
                if (destinationLanguage != string.Empty)
                {
                    translatedLibraries.Add(TranslateLibrary(sourceLibrary, destinationLanguage));
                }
                else
                    DebugLog("Unknown value " + destinationLanguage);
            }
            ShowTranslations();
            saveButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string filePath = openFileDialog.FileName.Replace(openFileDialog.SafeFileName, "");
            foreach (TranslationLibrary translationLibrary in translatedLibraries)
            {
                XmlDocument xmlDocument = ConvertXML(translationLibrary);
                string fileName = $"{filePath}\\{translationLibrary.Language}.xml";
                xmlDocument.Save(fileName);
            }
            DebugLog("Saving succesfully!");
        }

        private TranslationLibrary TranslateLibrary(TranslationLibrary sourceLibrary, string destinationLanguage)
        {
            var translator = new AggregateTranslator();
            Dictionary<string, string> translatedLibrary = new Dictionary<string, string>();

            string sourceLanguage = sourceLibrary.Language;
            foreach (KeyValuePair<string, string> translations in sourceLibrary.Translations)
            {
                string translated = TranslateString(translations.Value, sourceLanguage, destinationLanguage);
                translatedLibrary.Add(translations.Key, translated);
                DebugLog($"{sourceLanguage}: \"{translations.Value}\" translated to {destinationLanguage}: \"{translated}\" ");
            }

            return new TranslationLibrary(destinationLanguage, translatedLibrary);
        }

        private string TranslateString(string sourceString, string sourceLanguage, string destinationLanguage)
        {
            return Task.Run(async () =>
            {
                var translator = new AggregateTranslator();
                var result = await translator.TranslateAsync(sourceString, destinationLanguage, sourceLanguage);
                return result.Translation;
            }
            ).Result;
        }

        private void languagesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            bool itemState = !languagesCheckedListBox.GetItemChecked(e.Index);
            var item = Language.LanguageDictionary.ToArray()[e.Index];
            string language = item.Value.Name;
            if (itemState)
                translateLanguages.Add(language);
            else
            {
                for (int i = 0; i < translateLanguages.Count; i++)
                    if (translateLanguages[i] == language)
                        translateLanguages.Remove(translateLanguages[i]);
            }
        }

        private void SetLanguages()
        {
            foreach (KeyValuePair<string, Language> kvp in Language.LanguageDictionary.ToList())
            {
                sourceComboBox.Items.Add(kvp.Value.Name);
                if (kvp.Value.Name == FROM_LANGUAGE_BASE)
                {
                    sourceComboBox.SelectedIndex = sourceComboBox.Items.Count - 1;
                }
                languagesCheckedListBox.Items.Add(kvp.Value.Name);
            }
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
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabPage.Controls.Add(dataGridView);
            translationsTabControl.TabPages.Add(tabPage);
        }

        private TranslationLibrary InitFile(XmlDocument file)
        {
            Dictionary<string, string> sourceLibrary = new();

            XmlElement root = file.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//string");

            foreach (XmlNode node in nodes)
            {
                string key = node.Attributes["name"].Value;
                if (!sourceLibrary.ContainsKey(key))
                    sourceLibrary.Add(key, node.InnerText);

            }
            DebugLog("Library is loaded! Total string count is: " + sourceLibrary.Count);

            string sourceLanguage = sourceComboBox.SelectedItem.ToString();
            return new TranslationLibrary(sourceLanguage, sourceLibrary);
        }

        private XmlDocument ConvertXML(TranslationLibrary translationLibrary)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement rootElement = xmlDocument.CreateElement("root");
            xmlDocument.AppendChild(rootElement);

            foreach (KeyValuePair<string, string> translations in translationLibrary.Translations)
            {
                XmlElement element = xmlDocument.CreateElement("string");
                element.SetAttribute("name", translations.Key);
                element.InnerText = translations.Value;
                rootElement.AppendChild(element);
            }

            return xmlDocument;
        }

        private void DebugLog(string logText)
        {
            if (logTextBox.Text.Length == 0) logTextBox.Text = logText;
            else logTextBox.Text += $"\n{logText}";
        }
    }
}