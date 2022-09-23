using Dictionary_Blazor.Api.Extensions;
using Dictionary_Blazor.Api.Models;
using Dictionary_Blazor.Api.Services.Contracts;
using Dictionary_Blazor.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary_Blazor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordController: ControllerBase
    {
        private readonly WordContract wordContract;
        public WordController(WordContract wordContract)
        {
            this.wordContract = wordContract;
        }
        [HttpGet("/api/word/all")]
        public async Task<ActionResult<List<WordDto>>> GetAllWords()
        {
            try
            {
                List<Word> words = await wordContract.GetWords();
                if (words == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(words.ConvertToDto());
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database!");
            }
        }
        [HttpGet("/api/word/suggest/")]
        public async Task<ActionResult<List<WordDto>>> GetSuggestWord([FromQuery(Name = "word")] string word)
        {
            try
            {
                List<Word> words = await wordContract.GetSuggestWord(word.Replace("_", " "));
                if (words == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(words.ConvertToDto());
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database!");
            }
        }
        [HttpGet("/api/word/specific/")]
        public async Task<ActionResult<List<WordDto>>> GetSpecificWord([FromQuery(Name = "word")] string word)
        {
            try
            {
                List<Word> words = await wordContract.GetWordByKeyword(word.Replace("_", " "));
                if (words == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(words.ConvertToDto());
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database!");
            }
        }
    }
}
