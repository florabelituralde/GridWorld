using GridWorld2DGame.Models;
using GridWorld2DGame.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GridWorld2DGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaveGameController : ControllerBase
    {
        private readonly ISavedGameData _savedGameData;

        public SaveGameController(ISavedGameData savedGameData)
        {
            _savedGameData = savedGameData;
        }

        [HttpPost("saved-games")]
        [Route("[controller]/saved-games")]
        public IActionResult SaveGame([FromBody] PlayerState gameData)
        {
            _savedGameData.SaveGame(gameData);
            return Ok();
        }

        [HttpGet("saved-games/{id}")]
        [Route("[controller]/saved-games/{id}")]
        public ActionResult<PlayerState> GetSavedGame(int id)
        {
            var savedGame = _savedGameData.GetSavedGame(id);

            if (savedGame == null)
            {
                return NotFound();
            }

            return savedGame;
        }
    }
}
