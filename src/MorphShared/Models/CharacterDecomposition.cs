namespace MorphShared.Models
{
    public class CharacterDecomposition
    {
        public string? Character { get; set; }
        public int FreqRank { get; set; }
        public string? Pinyin { get; set; }
        public string[]? Definitions { get; set; }
        public int StrokeCount { get; set; }
        public bool IsUnbound { get; set; }
        public WordFrequency[]? CommonWords { get; set; }
        public SemanticRadical? SemanticRadical { get; set; }
    }
}
