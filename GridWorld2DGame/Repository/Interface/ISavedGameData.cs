using GridWorld2DGame.Models;

namespace GridWorld2DGame.Repository.Interface
{
    public interface ISavedGameData
    {
        string LoadGame(int playerId);
        void SaveGame(int playerId, string playerState);
    }
}