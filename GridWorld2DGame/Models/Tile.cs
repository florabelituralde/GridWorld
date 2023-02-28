using static System.Net.Mime.MediaTypeNames;

namespace GridWorld2DGame.Models
{
    public class Tile
    {
        public int Health { get; set; }
        public int Moves { get; set; }

        public Tile(int health, int moves)
        {
            Health = health;
            Moves = moves;
        }
    }
}
