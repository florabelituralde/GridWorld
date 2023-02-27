using GridWorld2DGame.Models;
using GridWorld2DGame.Repository.Interface;

namespace GridWorld2DGame.Repository
{
    public class SavedGameData : ISavedGameData
    {
        private readonly Dictionary<int, PlayerState> _savedGames = new Dictionary<int, PlayerState>();

        public PlayerState GetSavedGame(int id)
        {
            _savedGames.TryGetValue(id, out PlayerState playerState);
            return playerState;
        }

        public void SaveGame(PlayerState playerState)
        {
            var currentState = new PlayerState
            {
                PlayerId = playerState.PlayerId,
                Health = playerState.Health,
                Moves = playerState.Moves,
                Row = playerState.Row,
                Column = playerState.Column
            };

            _savedGames[playerState.PlayerId] = currentState;
        }
    }
}
