using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform mazeRunner;
    private Camera camera;
    private const float CameraDistance = 0.5f;

    // Initialize the camera component
    private void Start()
    {
        camera = Camera.main;
    }

    // Update the camera position to follow the maze runner
    private void Update()
    {
        Vector3 cameraPosition = new Vector3(mazeRunner.position.x, mazeRunner.position.y, mazeRunner.position.z - CameraDistance);
        camera.transform.position = cameraPosition;
    }
}
