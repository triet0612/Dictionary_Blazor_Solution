using Dictionary_Blazor.Api.Models;
namespace Dictionary_Blazor.Api.Services.Contracts;

public interface WordContract
{
    Task<List<Word>> GetWords();
    Task<List<Word>> GetWordByKeyword(string keyword);
    Task<List<Word>> GetSuggestWord(string curWord);
}
