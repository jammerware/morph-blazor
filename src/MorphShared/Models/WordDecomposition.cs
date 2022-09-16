namespace MorphShared.Models
{
    public class WordDecomposition
    {
        public Word? Word { get; set; }
        public CharacterDecomposition[]? Characters { get; set; }
    }
}
