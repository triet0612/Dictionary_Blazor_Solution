using Microsoft.AspNetCore.Components;
using Dictionary_Blazor.Models.Dtos;
using Dictionary_Blazor.Web.Services.Contracts;

namespace Dictionary_Blazor.Web.Pages
{
    public class WordBase: ComponentBase
    {
        [Inject]
        public IDictionaryService DictionaryService { get; set; }
        public IEnumerable<WordDto> Words { get; set; }
        public string searchword { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Words = await DictionaryService.GetWords();
            searchword = "";
        }
        protected async Task GetWordSpecificWord(string word)
        {
            if (word == "")
            {
                Words = await DictionaryService.GetWords();
            }
            else
            {
                Words = await DictionaryService.GetSpecificWords(word == "" ? " " : word);
            }
        }
        protected async Task GetSuggestWord(string word)
        {
            if (word == "")
                Words = await DictionaryService.GetWords();
            else
                Words = await DictionaryService.GetSuggestWords(word == ""? " ": word);
        }
    }
}
