using GridWorld2DGame.Models;

namespace GridWorld2DGame.Repository.Interface
{
    public interface IBoardGameData
    {
        Dictionary<string, Tile> GetBoardGameConfig();
    }
}
