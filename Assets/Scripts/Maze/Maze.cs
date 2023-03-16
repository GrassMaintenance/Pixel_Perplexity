using UnityEngine;

namespace Maze {
    public class Maze
    {
        int width;
        int height;
        bool[,] grid;
        System.Random random;
        int startX;
        int startY;

        public bool[,] Grid => grid;

        public Maze(int width, int height, System.Random random)
        {
            this.width = width;
            this.height = height;
            this.startX = 1;
            this.startY = 1;
            this.random = random;
        }

        public Maze(int width, int height, int startX, int startY, System.Random random)
        {
            this.width = width;
            this.height = height;
            this.startX = startX;
            this.startY = startY;
            this.random = random;
        }

        public void Generate()
        {
            grid = new bool[width, height];
            grid[startX, startY] = true;
            MazeDigger(startX, startY);
        }

                public Vector3 GetGoalPosition()
        {
            int radius = 2;
            int endX = width - startX;
            int endY = height - startY;
            for (int x = endX - radius; x <= endX + radius; x++)
            {
                for (int y = endY - radius; y <= endY + radius; y++)
                {
                    if (GetCell(x, y))
                    {
                        return new Vector3(x, y, 0);
                    }
                }
            }
            return new Vector3(1000, 1000, 0);
        }


        public bool GetCell(int x, int y)
        {
            if (x >= width || x < 0 || y >= height || y <= 0)
            {
                return false;
            }
            return grid[x, y];
        }

        void MazeDigger(int x, int y)
        {
            Direction[] directions = (Direction[]) System.Enum.GetValues(typeof(Direction));
            Tools.Shuffle(directions, random);

            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case Direction.Up:
                        if (y - 2 <= 0) continue;
                        if (grid[x, y - 2]) continue;
                        grid[x, y - 2] = true;
                        grid[x, y - 1] = true;
                        MazeDigger(x, y - 2);
                        break;
                    case Direction.Left:
                        if (x - 2 <= 0) continue;
                        if (grid[x - 2, y]) continue;
                        grid[x - 2, y] = true;
                        grid[x - 1, y] = true;
                        MazeDigger(x - 2, y);
                        break;
                    case Direction.Right:
                        if (x + 2 >= width - 1) continue;
                        if (grid[x + 2, y]) continue;
                        grid[x + 2, y] = true;
                        grid[x + 1, y] = true;
                        MazeDigger(x + 2, y);
                        break;
                    case Direction.Down:
                        if (y + 2 >= height - 1) continue;
                        if (grid[x, y + 2]) continue;
                        grid[x, y + 2] = true;
                        grid[x, y + 1] = true;
                        MazeDigger(x, y + 2);
                        break;
                }
            }
        }
        enum Direction
        {
            Up = 1,
            Left = 2,
            Down = 3,
            Right = 4
        }
    }
}