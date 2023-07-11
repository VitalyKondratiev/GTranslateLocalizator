using GTranslateLocalizatorApp.Services.Contracts;
using GTranslateLocalizatorApp.Structures;
using System.Xml;

namespace GTranslateLocalizatorApp.Services
{
    public class FileXmlService: IFileXmlService
    {
        public TranslationLibrary LoadFromFile(string filePath, LibreLanguage language)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            return ToTranslationLibrary(xmlDocument, language);
        }

        public void SaveToFile(TranslationLibrary translationLibrary, string fileName) 
        {
            XmlDocument xmlDocument = FromTranslationLibrary(translationLibrary);
            xmlDocument.Save(fileName);
        }

        private XmlDocument FromTranslationLibrary(TranslationLibrary translationLibrary)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.AppendChild(xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null));
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

        private TranslationLibrary ToTranslationLibrary(XmlDocument file, LibreLanguage language)
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

            return new TranslationLibrary(language, sourceLibrary);
        }
    }
}
