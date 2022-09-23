namespace Dictionary_Blazor.Api.Models
{
    public class Word
    {
        public string? Keyword { get; set; }
        public string? Definition { get; set; }
        public Word(string k, string d)
        {
            this.Keyword = k;
            this.Definition = d;
        }
    }
}
