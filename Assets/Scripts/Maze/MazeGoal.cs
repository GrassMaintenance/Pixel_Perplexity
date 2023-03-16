using UnityEngine;

namespace Maze
{
    public class MazeGoal : MonoBehaviour
    {
        public Sprite closedGoalSprite;
        public Sprite openedGoalSprite;
        private SpriteRenderer spriteRenderer;

        // Set the initial sprite for the goal to be in the closed state
        void Start()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = closedGoalSprite;
            }
        }

        // Change the sprite of the goal to be in the opened state
        public void OpenGoal()
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = openedGoalSprite;
            }
        }

        // Detect when the player has entered the goal area and send a message to the parent object
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                transform.parent.SendMessage("OnGoalReached", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
