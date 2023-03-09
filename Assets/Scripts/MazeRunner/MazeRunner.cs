using System;
using UnityEngine;

namespace PixelPerplexity.Player {
    public class MazeRunner : MonoBehaviour {
        private readonly float walkSpeed = 4;
        private readonly float rotateSpeed = 4;
        private PlayerControls playerControls;
        public event Action OnPlayerPaused;
        // public Transform rotationTransform;
        // Vector2 direction = Vector2.zero;
        // int targetX = 1;
        // int targetY = 1;
        // int currentX = 1;
        // int currentY = 1;
        // float currentAngle;
        // float lastAngle;

        private void Awake() => playerControls = new PlayerControls();
        private void OnEnable() => playerControls.Enable();
        private void OnDisable() => playerControls.Disable();

        void Update() {
            // bool targetReached = transform.position.x == targetX && transform.position.y == targetY;
            // currentX = Mathf.FloorToInt(transform.position.x);
            // currentY = Mathf.FloorToInt(transform.position.y);
            // direction.x = Input.GetAxisRaw("Horizontal");
            // direction.y = Input.GetAxisRaw("Vertical");
            //
            // float angle = direction.x > 0 ? 270 : direction.x < 0 ? 90 : direction.y > 0 ? 0 : direction.y < 0 ? 180 : lastAngle;
            //
            // if (MazeGenerator.instance.GetMazeGridCell(currentX + (int)direction.x, currentY + (int)direction.y) && targetReached)
            // {
            //     targetX = currentX + (int)direction.x;
            //     targetY = currentY + (int)direction.y;
            // }
            // currentAngle = Mathf.LerpAngle(currentAngle, angle, rotationSpeed * Time.deltaTime);
            // transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, targetY), walkSpeed * Time.deltaTime);
            // rotationTransform.rotation = Quaternion.Euler(Vector3.up * currentAngle);
            // lastAngle = angle;
            Vector2 playerInput = playerControls.Player.WASD.ReadValue<Vector2>();
            playerControls.Player.Pause.performed += _ => InvokePauseEvent();
            MovePlayer(playerInput);
            RotatePlayer(playerInput);
        }

        void InvokePauseEvent() => OnPlayerPaused?.Invoke();
        
        void RotatePlayer(Vector2 input) {

            if (input == Vector2.zero) return;
        
            float zRotation = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg - 90;
            Quaternion finalRotation = Quaternion.Euler(0, 0, zRotation).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, finalRotation, rotateSpeed * Time.deltaTime);
        }
    
        void MovePlayer(Vector2 input) {
            Vector3 movement = new Vector3(input.x, input.y, 0).normalized;
            transform.Translate(walkSpeed * Time.deltaTime * movement , Space.World);
        }
    }
}
