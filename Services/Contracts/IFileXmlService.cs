﻿using GTranslateLocalizatorApp.Structures;

namespace GTranslateLocalizatorApp.Services.Contracts
{
    public interface IFileXmlService
    {
        public TranslationLibrary LoadFromFile(string filePath, LibreLanguage language);

        public void SaveToFile(TranslationLibrary translationLibrary, string fileName);
    }
}
