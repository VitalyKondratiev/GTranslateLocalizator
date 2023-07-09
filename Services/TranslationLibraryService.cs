using GTranslate;
using GTranslate.Translators;
using GTranslateLocalizatorApp.Services.Contracts;
using GTranslateLocalizatorApp.Structures;

namespace GTranslateLocalizatorApp.Services
{
    public class TranslationLibraryService : ITranslationLibraryService
    {
        public static readonly string FromLanguageBase = "Russian";

        private readonly List<string> Languages = new();

        public TranslationLibraryService() {
            foreach (KeyValuePair<string, Language> kvp in Language.LanguageDictionary.ToList())
            {
                Languages.Add(kvp.Value.Name);
            }
        }

        public List<string> GetLanguageList()
        {
            return Languages;
        }

        public TranslationLibrary TranslateLibrary(TranslationLibrary sourceLibrary, string destinationLanguage)
        {
            Dictionary<string, string> translatedLibrary = new Dictionary<string, string>();

            string sourceLanguage = sourceLibrary.Language;
            foreach (KeyValuePair<string, string> translations in sourceLibrary.Translations)
            {
                string translated = TranslateString(translations.Value, sourceLanguage, destinationLanguage);
                translatedLibrary.Add(translations.Key, translated);
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
    }
}
