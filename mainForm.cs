namespace GTranslateLocalizatorApp
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Xml;
    using System;

    using GTranslate;
    using GTranslate.Translators;
    using GTranslate.Results;

    public partial class mainForm : Form
    {
        private Dictionary<string, string> sourceLib = new Dictionary<string, string>();
        private List<string> translateLanguages = new();
        private Dictionary<string, XmlDocument> translated = new Dictionary<string, XmlDocument>();

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
                InitFile(doc);
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            string sourceLanguage = sourceComboBox.SelectedItem.ToString();

            translated = new Dictionary<string, XmlDocument>();
            foreach (string destinationLanguage in translateLanguages)
            {
                if (destinationLanguage != string.Empty)
                {
                    DebugLog(destinationLanguage);
                    Dictionary<string, string> translatedLib = TranslateDictionary(sourceLib, sourceLanguage, destinationLanguage);
                    translated.Add(destinationLanguage, ConvertXML(translatedLib));
                }
                else
                    DebugLog("Unknown value " + destinationLanguage);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string filePath = openFileDialog.FileName.Replace(openFileDialog.SafeFileName, "");
            foreach (KeyValuePair<string, XmlDocument> xmlDocument in translated)
            {
                string fileName = $"{filePath}\\{xmlDocument.Key}.xml";
                xmlDocument.Value.Save(fileName);
            }
            DebugLog("Saving succesfully!");
        }

        private Dictionary<string, string> TranslateDictionary(Dictionary<string, string> sourceLib, string sourceLanguage, string destinationLanguage)
        {
            var translator = new AggregateTranslator();
            Dictionary<string, string> translatedLib = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> pair in sourceLib)
            {
                string translated = TranslateString(pair.Value, sourceLanguage, destinationLanguage);
                DebugLog(translated);
                translatedLib.Add(pair.Key, translated);
            }

            return translatedLib;
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

        private void InitFile(XmlDocument file)
        {
            XmlElement root = file.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//string");

            foreach (XmlNode node in nodes)
            {
                string key = node.Attributes["name"].Value;
                if (!sourceLib.ContainsKey(key))
                    sourceLib.Add(key, node.InnerText);

            }
            DebugLog("Library is loaded! Total string count is: " + sourceLib.Count);
        }

        private XmlDocument ConvertXML(Dictionary<string, string> saveLib)
        {

            // Создаем XML документ и корневой элемент
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement rootElement = xmlDoc.CreateElement("root");
            xmlDoc.AppendChild(rootElement);

            // Преобразуем Dictionary в XML элементы
            foreach (var pair in saveLib)
            {
                XmlElement element = xmlDoc.CreateElement("string");
                element.SetAttribute("name", pair.Key);
                element.InnerText = pair.Value;
                rootElement.AppendChild(element);
            }

            //// Сохраняем XML документ в файл
            //string fileName = "dictionary.xml";
            //xmlDoc.Save(fileName);
            return xmlDoc;
        }

        private void DebugLog(string logText)
        {
            if (logTextBox.Text.Length == 0) logTextBox.Text = logText;
            else logTextBox.Text += $"\n{logText}";
        }
    }
}