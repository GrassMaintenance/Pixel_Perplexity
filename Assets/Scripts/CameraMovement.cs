using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField] private Transform mazeRunner;
    private Camera camera;
    private const float CAMERA_DISTANCE = 0.5f;
    private void Start() => camera = Camera.main;

    private void Update() {
        Vector3 cameraPosition = new Vector3(mazeRunner.position.x, mazeRunner.position.y, mazeRunner.position.z - CAMERA_DISTANCE);
        camera.transform.position = cameraPosition;
    }
}
