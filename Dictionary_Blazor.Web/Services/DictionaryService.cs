using Dictionary_Blazor.Models.Dtos;
using Dictionary_Blazor.Web.Services.Contracts;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Dictionary_Blazor.Web.Services
{
    public class DictionaryService: IDictionaryService
    {
        private readonly HttpClient httpClient;
        public DictionaryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        async Task<IEnumerable<WordDto>> IDictionaryService.GetSpecificWords(string word)
        {
            try
            {
                var words = await this.httpClient.GetFromJsonAsync<IEnumerable<WordDto>>($"api/word/specific/?word={word.Replace(" ", "_")}");
                return words;
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<IEnumerable<WordDto>> IDictionaryService.GetSuggestWords(string word)
        {
            try
            {
                var words = await this.httpClient.GetFromJsonAsync<IEnumerable<WordDto>>($"api/word/suggest/?word={word.Replace(" ", "_")}");
                return words;
            }
            catch (Exception)
            {

                throw;
            }
        }

        async Task<IEnumerable<WordDto>> IDictionaryService.GetWords()
        {
            try
            {
                var words = await this.httpClient.GetFromJsonAsync<IEnumerable<WordDto>>("api/word/all");
                return words;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
