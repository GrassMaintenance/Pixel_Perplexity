using UnityEngine;

namespace Maze {
    public class MazeKey : MonoBehaviour {

        void OnTriggerEnter2D() {
            transform.parent.SendMessage("OnKeyFound", SendMessageOptions.DontRequireReceiver);
            GameObject.Destroy(gameObject);
        }

    }
}
