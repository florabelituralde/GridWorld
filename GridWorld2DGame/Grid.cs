using System.Drawing;
using System.Security.AccessControl;
using System.Text;

namespace GridWorld2DGame
{
    // In a 100 by 100 2-D grid world, you are given a starting point A on one side of the grid, and an
    // ending point B on the other side of the grid.Your objective is to get from point A to point B.
    // Each grid space can be in a state of[“Blank”, “Speeder”, “Lava”, “Mud”]. You start out with 200
    // points of health and 450 moves.Below is a mapping of how much your health and moves are affected by landing on a grid space.
     // [
    // “Blank”: {“Health”: 0, “Moves”: -1},
    // “Speeder”: {“Health”: -5, “Moves”: 0},
    // “Lava”: {“Health”: -50, “Moves”: -10},
    // “Mud”: {“Health”: -10, “Moves”: -5},
    // ]

    public class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public int Health { get; set; }
        public int Moves { get; set; }
        public string[,] GridSpaces { get; set; }

        public Grid(int width, int height, Point start, Point end, int health, int moves, string[,] gridSpaces)
        {
            Width = width;
            Height = height;
            Start = start;
            End = end;
            Health = health;
            Moves = moves;
            GridSpaces = gridSpaces;
        }

        public void PrintGrid()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    sb.Append(GridSpaces[i, j]);
                }
                sb.AppendLine();
            }
            System.Console.WriteLine(sb.ToString());
        }

        public void PrintGridWithHealthAndMoves()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    sb.Append(GridSpaces[i, j]);
                }
                sb.AppendLine();
            }
            sb.AppendLine($"Health: {Health}");
            sb.AppendLine($"Moves: {Moves}");
            System.Console.WriteLine(sb.ToString());
        }

        public void PrintGridWithHealthAndMovesAndStartAndEnd()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    if (i == Start.X && j == Start.Y)
                    {
                        sb.Append("A");
                    }
                    else if (i == End.X && j == End.Y)
                    {
                        sb.Append("B");
                    }
                    else
                    {
                        sb.Append(GridSpaces[i, j]);
                    }
                }
                sb.AppendLine();
            }
            sb.AppendLine($"Health: {Health}");
            sb.AppendLine($"Moves: {Moves}");
            System.Console.WriteLine(sb.ToString());
        }

        public void PrintGridWithHealthAndMovesAndStartAndEndAndCurrentPosition(Point currentPosition)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    if (i == Start.X && j == Start.Y)
                    {
                        sb.Append("A");
                    }
                    else if (i == End.X && j == End.Y)
                    {
                        sb.Append("B");
                    }
                    else if (i == currentPosition.X && j == currentPosition.Y)
                    {
                        sb.Append("X");
                    }
                    else
                    {
                        sb.Append(GridSpaces[i, j]);
                    }
                }
                sb.AppendLine();
            }
            sb.AppendLine($"Health: {Health}");
            sb.AppendLine($"Moves: {Moves}");
            System.Console.WriteLine(sb.ToString());
        }

        public void PrintGridWithHealthAndMovesAndStartAndEndAndCurrentPositionAndPath(Point currentPosition, Point[] path)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    if (i == Start.X && j == Start.Y)
                    {
                        sb.Append("A");
                    }
                    else if (i == End.X && j == End.Y)
                    {
                        sb.Append("B");
                    }
                    else if (i == currentPosition.X && j == currentPosition.Y)
                    {
                        sb.Append("X");
                    }
                    else if (path.Contains(new Point(i, j)))
                    {
                        sb.Append("O");
                    }
                    else
                    {
                        sb.Append(GridSpaces[i, j]);
                    }
                }
                sb.AppendLine();
            }
            sb.AppendLine($"Health: {Health}");
            sb.AppendLine($"Moves: {Moves}");
            System.Console.WriteLine(sb.ToString());
        }   
    }
}
