using UnityEngine;

namespace Maze {
    public class MazeSprite : MonoBehaviour 
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake() 
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetSprite(Sprite sprite, int sortingOrder) 
        {
            _spriteRenderer.sprite = sprite;
            _spriteRenderer.sortingOrder = sortingOrder;
        }

        public void SetSprite(Sprite sprite) 
        {
            SetSprite(sprite, 0);
        }
    }
}
