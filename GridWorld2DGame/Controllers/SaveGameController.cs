using GridWorld2DGame.Models;
using GridWorld2DGame.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public IActionResult SaveGame([FromBody] PlayerState playerState)
        {
            try
            {
                _savedGameData.SaveGame(playerState.PlayerId, JsonConvert.SerializeObject(playerState));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("saved-games/{playerId}")]
        public ActionResult<PlayerState> GetSavedGame(int playerId)
        {
            try
            {
                string gameData = _savedGameData.LoadGame(playerId);
                PlayerState playerState = JsonConvert.DeserializeObject<PlayerState>(gameData);
                return Ok(playerState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
