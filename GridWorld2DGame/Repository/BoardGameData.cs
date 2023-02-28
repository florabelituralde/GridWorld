using GridWorld2DGame.Models;
using GridWorld2DGame.Repository.Interface;

namespace GridWorld2DGame.Repository
{
    public class BoardGameData : IBoardGameData
    {

        public Dictionary<string, Tile> GetBoardGameConfig()
        {
            var boardConfiguration = new BoardConfiguration();
            var configDictionary = new Dictionary<string, Tile>
            {
                { "Blank", new Tile(0, -1) },
                { "Speeder", new Tile(-5, 0) },
                { "Lava", new Tile(-50, -10) },
                { "Mud", new Tile(-10, -5) }
            };

            return configDictionary;
        }

    }
}
