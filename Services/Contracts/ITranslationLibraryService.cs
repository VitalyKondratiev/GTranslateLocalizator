using GTranslateLocalizatorApp.Structures;

namespace GTranslateLocalizatorApp.Services.Contracts
{
    public interface ITranslationLibraryService
    {
        public List<string> GetLanguageList();

        public TranslationLibrary TranslateLibrary(TranslationLibrary sourceLibrary, string destinationLanguage);
    }
}
