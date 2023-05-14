namespace GTranslateLocalizatorApp.Structures
{
    public struct TranslationLibrary
    {
        public string Language;
        public Dictionary<string, string> Translations;

        public TranslationLibrary(string language, Dictionary<string, string> translations)
        {
            Language = language;
            Translations = translations;
        }
    }
}
