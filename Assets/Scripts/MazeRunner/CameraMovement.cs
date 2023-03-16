using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField] private Transform target;

    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    private Camera mainCamera;

    void Start() {
        mainCamera = GetComponent<Camera>();
    }

    void LateUpdate() {
        if (target) {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
