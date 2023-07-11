namespace GTranslateLocalizatorApp.Structures
{
    public struct TranslationLibrary
    {
        public LibreLanguage Language;
        public Dictionary<string, string> Translations;

        public TranslationLibrary(LibreLanguage language, Dictionary<string, string> translations)
        {
            Language = language;
            Translations = translations;
        }

        public void SetLanguage(LibreLanguage language)
        {
            Language = language;
        }
    }
}
