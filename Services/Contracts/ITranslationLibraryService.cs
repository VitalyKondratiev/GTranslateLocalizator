using GTranslateLocalizatorApp.Structures;

namespace GTranslateLocalizatorApp.Services.Contracts
{
    public interface ITranslationLibraryService
    {
        public LibreLanguage[] GetLanguageList();

        public TranslationLibrary TranslateLibrary(TranslationLibrary sourceLibrary, LibreLanguage destinationLanguage);
    }
}
