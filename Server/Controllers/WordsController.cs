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
        public async Task<ActionResult<IEnumerable<Word>>> GetWords()
        {
            return await _context.Words.ToListAsync();
        }

        // GET: api/Words/5
        [HttpGet("search")]
        public async Task<ActionResult<Word>> SearchWords(
             [FromQuery]  Language language,
             [FromQuery]  int numberOfWords,
             [FromQuery] PartOfSpeech partOfSpeech)
        {
            var entity = language switch
            {
                Language.Japanese => await _context.Words.Where(x => x.PartOfSpeech == (int)partOfSpeech).ToArrayAsync(),
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

        // PUT: api/Words/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWord(int id, Word word)
        {
            if (id != word.Id)
            {
                return BadRequest();
            }

            _context.Entry(word).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Words
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Word>> PostWord(Word word)
        {
            _context.Words.Add(word);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWord", new { id = word.Id }, word);
        }

        // DELETE: api/Words/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWord(int id)
        {
            var word = await _context.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            _context.Words.Remove(word);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WordExists(int id)
        {
            return _context.Words.Any(e => e.Id == id);
        }
    }
}
