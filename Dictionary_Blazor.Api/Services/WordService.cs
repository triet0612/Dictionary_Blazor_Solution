using Dictionary_Blazor.Api.Models;
using Dictionary_Blazor.Api.Services.Contracts;
using Microsoft.Data.Sqlite;

namespace Dictionary_Blazor.Api.Services
{
    public class WordService : WordContract
    {
        private readonly SqliteConnection sConn;
        public WordService()
        {
            sConn = new SqliteConnection("Data source=Dictionary.db");
        }
        async Task<List<Word>> WordContract.GetWords()
        {
            List<Word> wordList = new();
            Word temp;
            using (sConn)
            {
                
                await sConn.OpenAsync();
                var command = sConn.CreateCommand();
                command.CommandText = $"SELECT * FROM ENVIE LIMIT 50";
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        temp = new Word(reader.GetString(0), reader.GetString(1));
                        wordList.Add(temp);
                    }
                }
                await command.DisposeAsync();
                await sConn.CloseAsync();
            }
            return wordList;
        }
        async Task<List<Word>> WordContract.GetWordByKeyword(string keyword)
        {
            List<Word> wordList = new();
            using (sConn)
            {
                await sConn.OpenAsync();
                var command = sConn.CreateCommand();
                command.CommandText = $"SELECT * FROM ENVIE WHERE Word like '{keyword}' LIMIT 50";
                Word temp;
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        temp = new Word(reader.GetString(0), reader.GetString(1));
                        wordList.Add(temp);
                    }
                }
                await command.DisposeAsync();
                await sConn.CloseAsync();
            }
            return wordList;
        }
        async Task<List<Word>> WordContract.GetSuggestWord(string curWord)
        {
            List<Word> wordList = new();
            using (sConn)
            {
                await sConn.OpenAsync();
                var command = sConn.CreateCommand();
                command.CommandText = $"SELECT * FROM ENVIE WHERE Word like '{curWord}%' LIMIT 50";
                Word temp;
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        temp = new Word(reader.GetString(0), reader.GetString(1));
                        wordList.Add(temp);
                    }
                }
                await command.DisposeAsync();
                await sConn.CloseAsync();
            }
            return wordList;
        }
    }
}
