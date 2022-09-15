namespace MorphShared.Models
{
    public class WordDecomposition
    {
        public string L1 { get; set; }
        public string Translation { get; set; }
        public string[]? Definitions { get; set; }
        public string? Pinyin { get; set; }
        public CharacterDecomposition[] Characters { get; set; }
    }
}
