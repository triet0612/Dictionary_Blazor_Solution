using Dictionary_Blazor.Models.Dtos;
namespace Dictionary_Blazor.Web.Services.Contracts
{
    public interface IDictionaryService
    {
        Task<IEnumerable<WordDto>> GetWords();
        Task<IEnumerable<WordDto>> GetSpecificWords(string word);
        Task<IEnumerable<WordDto>> GetSuggestWords(string word);
    }
}
