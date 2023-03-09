using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Button : MonoBehaviour {
    [SerializeField] private GameObject[] arrows;

    public void EnableArrows() {
        foreach (GameObject arrow in arrows) {
            arrow.SetActive(true);
        }
    }

    public void DisableArrows() {
        foreach (GameObject arrow in arrows) {
            arrow.SetActive(false);
        }
    }
}