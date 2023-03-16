using System.Collections.Generic;
using UnityEngine;

namespace Maze {
    [RequireComponent(typeof(Maze))]
    public class MazeGenerator : MonoBehaviour
    {
        public static MazeGenerator instance;

        [SerializeField] private int mazeWidth;
        [SerializeField] private int mazeHeight;
        [SerializeField] private string mazeSeed;

        [SerializeField] private Sprite floorSprite;
        [SerializeField] private Sprite roofSprite;
        [SerializeField] private Sprite wallSprite;
        [SerializeField] private Sprite wallCornerSprite;

        [SerializeField] private MazeSprite mazeSpritePrefab;

        private System.Random mazeRG;
        private Maze maze;
        public Vector3 mazeGoalPosition;

        public delegate void MazeReadyAction();
        public static event MazeReadyAction OnMazeReady;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            mazeRG = new System.Random(mazeSeed.GetHashCode());

            if (mazeWidth % 2 == 0)
            {
                mazeWidth++;
            }

            if (mazeHeight % 2 == 0)
            {
                mazeHeight++;
            }

            maze = new Maze(mazeWidth, mazeHeight, mazeRG);
            maze.Generate();

            mazeGoalPosition = maze.GetGoalPosition();

            DrawMaze();

            OnMazeReady?.Invoke();
        }

        private void DrawMaze()
        {
            for (int x = 0; x < mazeWidth; x++)
            {
                for (int y = 0; y < mazeHeight; y++)
                {
                    Vector3 position = new Vector3(x, y);

                    if (maze.Grid[x, y] == true)
                    {
                        CreateMazeSprite(position, floorSprite, transform, 0, mazeRG.Next(0, 4) * 90);
                    }
                    else
                    {
                        CreateMazeSprite(position, roofSprite, transform, 0, 0);
                        DrawWalls(x, y);
                    }
                }
            }
        }

        private void DrawWalls(int x, int y)
        {
            bool top = GetMazeGridCell(x, y + 1);
            bool bottom = GetMazeGridCell(x, y - 1);
            bool right = GetMazeGridCell(x + 1, y);
            bool left = GetMazeGridCell(x - 1, y);

            Vector3 position = new Vector3(x, y);

            if (top)
            {
                CreateMazeSprite(position, wallSprite, transform, 1, 0);
            }

            if (left)
            {
                CreateMazeSprite(position, wallSprite, transform, 1, 90);
            }

            if (bottom)
            {
                CreateMazeSprite(position, wallSprite, transform, 1, 180);
            }

            if (right)
            {
                CreateMazeSprite(position, wallSprite, transform, 1, 270);
            }

            if (!left && !top && x > 0 && y < mazeHeight - 1)
            {
                CreateMazeSprite(position, wallCornerSprite, transform, 1, 180);
            }

            if (!left && !bottom && x > 0 && y > 0)
            {
                CreateMazeSprite(position, wallCornerSprite, transform, 1, 90);
            }
        }


    public bool GetMazeGridCell(int x, int y)
    {
        return maze.GetCell(x, y);
    }

    public List<Vector3> GetRandomFloorPositions(int count)
    {
        List<Vector3> positions = new List<Vector3>();

        for (int i = 0; i < count; i++)
        {
            Vector3 position = Vector3.one;

            do
            {
                int posX = 0;
                int posY = 0;

                while (!GetMazeGridCell(posX, posY))
                {
                    posX = mazeRG.Next(3, mazeWidth);
                    posY = mazeRG.Next(3, mazeHeight);
                }

                position = new Vector3(posX, posY);
            } while (positions.Contains(position));

            positions.Add(position);
        }

        return positions;
    }

    void CreateMazeSprite(Vector3 position, Sprite sprite, Transform parent, int sortingOrder, float rotation)
    {
        var mazeSprite = Instantiate(mazeSpritePrefab, position, Quaternion.identity);
        mazeSprite.SetSprite(sprite, sortingOrder);
        mazeSprite.transform.SetParent(parent);
        mazeSprite.transform.Rotate(0, 0, rotation);
    }
}
}
