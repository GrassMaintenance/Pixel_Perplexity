using UnityEngine;

namespace Maze
{
    public class MazeKey : MonoBehaviour
    {
        // Detect when the player has entered the key area and send a message to the parent object
        void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the collider entering the trigger is tagged as "Player"
            if (other.CompareTag("Player"))
            {
                // Notify the parent object that a key has been found
                transform.parent.SendMessage("OnKeyFound", SendMessageOptions.DontRequireReceiver);

                // Destroy the key object
                GameObject.Destroy(gameObject);
            }
        }
    }
}
