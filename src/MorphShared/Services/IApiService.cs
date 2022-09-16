using MorphShared.Models;

namespace MorphShared.Services
{
    public interface IApiService
    {
        Task<CharacterDecomposition?> GetCharacterDetails(string character);
        Task<string[]> GetRecommendedSearchTerms();
        Task<WordDecomposition> GetWordDecomposition(string query);
        Task<TranslationResults> Translate(string[] queries);
    }
}