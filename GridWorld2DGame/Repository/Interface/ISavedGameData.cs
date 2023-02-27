using GridWorld2DGame.Models;

namespace GridWorld2DGame.Repository.Interface
{
    public interface ISavedGameData
    {
        PlayerState GetSavedGame(int id);
        void SaveGame(PlayerState playerState);
    }
}