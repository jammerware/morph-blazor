namespace MorphShared.Models
{
    public class TranslationResults
    {
        public string TargetLanguage { get; set; }
        public TranslationResult[] Translations { get; set; }
    }
}
