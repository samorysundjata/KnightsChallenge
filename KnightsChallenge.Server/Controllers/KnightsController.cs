using KnightsChallenge.Server.Application;
using KnightsChallenge.Server.Data;
using KnightsChallenge.Server.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace KnightsChallenge.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KnightsController : Controller
    {
        private readonly IMongoCollection<Knight> _knights;
        private readonly IKnightsApp _knightsApp;

        public KnightsController(MongoDBService mongoDBService)
        {
            _knights = mongoDBService.Database?.GetCollection<Knight>("Knights");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Knight>>> GetKnights(string filter = "")
        {
            List<Knight> knights;
            if (filter == "heroes")
            {
                knights = await _knights.Find(k => k.IsHero).ToListAsync();
            }
            else
            {
                knights = await _knights.Find(_ => true).ToListAsync();
            }
            return knights;
        }

        [HttpPost]
        public async Task<ActionResult<Knight>> CreateKnight(Knight knight)
        {
            knight.Attack = _knightsApp.CalculateAttack(knight);
            knight.Exp = _knightsApp.CalculateExp(knight.Birthday);
            await _knights.InsertOneAsync(knight);
            return knight;
        }

        [HttpGet("{id:length(24)}", Name = "GetKnight")]
        public async Task<ActionResult<Knight>> GetKnight(string id)
        {
            var knight = await _knights.Find(k => k.Id == id).FirstOrDefaultAsync();
            if (knight == null)
            {
                return NotFound();
            }
            return knight;
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteKnight(string id)
        {
            var knight = await _knights.FindOneAndDeleteAsync(k => k.Id == id);
            if (knight == null)
            {
                return NotFound();
            }
            knight.IsHero = true;
            await _knights.InsertOneAsync(knight);
            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateNickname(string id, [FromBody] string nickname)
        {
            var knight = await _knights.FindOneAndUpdateAsync(
                Builders<Knight>.Filter.Eq(k => k.Id, id),
                Builders<Knight>.Update.Set(k => k.Nickname, nickname));
            if (knight == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
