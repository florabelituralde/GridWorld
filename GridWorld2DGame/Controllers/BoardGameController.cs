using GridWorld2DGame.Models;
using GridWorld2DGame.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GridWorld2DGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardGameController : ControllerBase
    {
        private static int Health = 200;
        private static int Moves = 450;
        private static int Row = 0;
        private static int Column = 0;

        private readonly IBoardGameData _boardGameData;

        public BoardGameController(IBoardGameData boardGameData)
        {
            _boardGameData = boardGameData;
        }

        [HttpGet("start-game")]
        public IActionResult GetStartGame()
        {
            Random random = new Random();
            int playerId = random.Next(100000, 999999);

            return Ok(new
            {
                PlayerId = playerId,
                Health = Health,
                Moves = Moves,
                Row = Row,
                Column = Column
            });
        }

        [HttpPost("start-game")]
        public IActionResult SetStartGame([FromBody] PlayerState currentState)
        {
            Health = currentState.Health;
            Moves = currentState.Moves;
            Row = currentState.Row;
            Column = currentState.Column;
            return Ok();
        }

        [HttpGet("boardconfig")]
        public ActionResult<Dictionary<string, Tile>> GetBoardGameConfig()
        {
            var boardConfig = _boardGameData.GetBoardGameConfig();

            return boardConfig;
        }

    }
}
