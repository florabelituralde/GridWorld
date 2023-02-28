using GridWorld2DGame.Models;
using GridWorld2DGame.Repository.Interface;

namespace GridWorld2DGame.Repository
{
    public class SavedGameData : ISavedGameData
    {
        private readonly Dictionary<int, string> _savedGames = new Dictionary<int, string>();

        public void SaveGame(int playerId, string gameData)
        {
            _savedGames[playerId] = gameData;
        }

        public string LoadGame(int playerId)
        {
            if (_savedGames.TryGetValue(playerId, out string gameData))
            {
                return gameData;
            }
            else
            {
                throw new ArgumentException($"No saved game found for player ID {playerId}");
            }
        }
    }
}
