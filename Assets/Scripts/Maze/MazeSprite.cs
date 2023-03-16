using UnityEngine;

namespace Maze
{
    public class MazeSprite : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        // Get the SpriteRenderer component on Awake
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Set the sprite and its sorting order
        public void SetSprite(Sprite sprite, int sortingOrder)
        {
            _spriteRenderer.sprite = sprite;
            _spriteRenderer.sortingOrder = sortingOrder;
        }

        // Overloaded method to set the sprite without specifying a sorting order
        public void SetSprite(Sprite sprite)
        {
            SetSprite(sprite, 0);
        }
    }
}
