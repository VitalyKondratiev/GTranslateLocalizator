
using GTranslateLocalizatorApp.Services.Contracts;
using GTranslateLocalizatorApp.Structures;

namespace GTranslateLocalizatorApp.Services
{
    public class TranslationLibraryService : ITranslationLibraryService
    {
        public static readonly string FromLanguageBase = "ru";

        private readonly LibreLanguage[] Languages;

        public TranslationLibraryService() {
            Languages = LibreTranslateClientService.GetLanguages();
        }

        public LibreLanguage[] GetLanguageList()
        {
            return Languages;
        }

        public TranslationLibrary TranslateLibrary(TranslationLibrary sourceLibrary, LibreLanguage destinationLanguage)
        {
            Dictionary<string, string> translatedLibrary = new Dictionary<string, string>();

            string[] keys = sourceLibrary.Translations.Keys.ToArray();
            string[] untranslated = sourceLibrary.Translations.Values.ToArray();

            for (int i = 0; i < untranslated.Length; i += 100)
            {
                int size = Math.Min(100, untranslated.Length - i);
                string[] untranslatedChunk = new string[size];
                Array.Copy(untranslated, i, untranslatedChunk, 0, size);
                
                string[] translated = TranslateStrings(untranslatedChunk, sourceLibrary.Language.code, destinationLanguage.code);
                int index = i;
                int index2 = 0;
                foreach (string tranlatedS in translated)
                {
                    translatedLibrary.Add(keys[index++], translated[index2++]);
                }
            }

            return new TranslationLibrary(destinationLanguage, translatedLibrary);
        }

        private string[] TranslateStrings(string[] sourceStrings, string sourceLanguage, string destinationLanguage)
        {
            return Task.Run(async () =>
            {
                var translator = new LibreTranslateClientService();
                return await translator.TranslateAsync(new TranslationTask(sourceStrings, sourceLanguage, destinationLanguage));
            }
            ).Result;
        }
    }
}
