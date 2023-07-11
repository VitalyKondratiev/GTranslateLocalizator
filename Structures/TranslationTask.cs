

namespace GTranslateLocalizatorApp.Structures
{
    public struct TranslationTask
    {
        public readonly string[] q;
        public readonly string source;
        public readonly string target;

        public TranslationTask(string[] q, string source, string target)
        {
            this.q = q;
            this.source = source;
            this.target = target;
        }
    }
}
