using Dictionary_Blazor.Models.Dtos;
using Dictionary_Blazor.Api.Models;

namespace Dictionary_Blazor.Api.Extensions
{
    public static class WordDtoConvert
    {
        public static IEnumerable<WordDto> ConvertToDto(this IEnumerable<Word> words)
        {
            return (from word in words
                    select new WordDto
                    {
                        Keyword = word.Keyword,
                        Definition = word.Definition
                    }).ToList();
        }
    }
}
