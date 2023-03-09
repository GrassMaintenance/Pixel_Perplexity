using UnityEngine;

namespace Maze {
    public class MazeGoal : MonoBehaviour {

        public Sprite closedGoalSprite;
        public Sprite openedGoalSprite;
        private SpriteRenderer spriteRenderer;

        void Start() {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
             if (spriteRenderer != null) {
                 spriteRenderer.sprite = closedGoalSprite;
            }
        }

        public void OpenGoal() {
            if (spriteRenderer != null) {
                spriteRenderer.sprite = openedGoalSprite;
            }
        }

        void OnTriggerEnter2D() {
            transform.parent.SendMessage("OnGoalReached", SendMessageOptions.DontRequireReceiver);
        }
    }
}
