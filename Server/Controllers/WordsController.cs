using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WordsCombiner.Server.Data;
using WordsCombiner.Shared;
using WordsCombiner.Shared.Model;
using WordsCombiner.Shared.Utility;
using System.Linq;

namespace WordsCombiner.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IRandomNumbers _randomNumbers;

        public WordsController(AppDbContext context, IRandomNumbers randomNumbers)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _randomNumbers = randomNumbers ?? throw new ArgumentNullException(nameof(randomNumbers));
        }

        // GET: api/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JapaneseWord>>> GetWords()
        {
            return await _context.JapaneseWords.ToListAsync();
        }

        // GET: api/Words/search
        [HttpGet("search")]
        public async Task<ActionResult<JapaneseWord>> SearchWords(
             [FromQuery]  Language language,
             [FromQuery]  int numberOfWords,
             [FromQuery] PartOfSpeech partOfSpeech)
        {
            var entity = language switch
            {
                Language.Japanese => await _context.JapaneseWords.Where(x => x.PartOfSpeech == (int)partOfSpeech).ToArrayAsync(),
                // TODO: #8 英単語を取得できるようにする
                Language.English => throw new NotImplementedException(),
                _ => throw new NotImplementedException()
            };

            // 取得した entity の中から画面に表示する単語をランダムに選択する 
            var numbers = _randomNumbers.GetUniqRandomNumbers(0, entity.Length-1, numberOfWords);
            var words = numbers.Select(number => entity[number]);
            if (words == null)
            {
                return NotFound();
            }

            return Ok(words);
        }
    }
}
