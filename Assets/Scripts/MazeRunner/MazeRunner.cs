using System;
using UnityEngine;

namespace PixelPerplexity.Player
{
    public class MazeRunner : MonoBehaviour
    {
        private readonly float walkSpeed = 4;
        private readonly float rotateSpeed = 4;
        private PlayerControls playerControls;
        public event Action OnPlayerPaused;

        private Rigidbody2D rb2d;
        private Vector2 moveInput;

        private void Awake()
        {
            playerControls = new PlayerControls();
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() => playerControls.Enable();
        private void OnDisable() => playerControls.Disable();

        private void Update()
        {
            moveInput = playerControls.Player.WASD.ReadValue<Vector2>();
            playerControls.Player.Pause.performed += _ => InvokePauseEvent();
            RotatePlayer(moveInput);
        }

        private void FixedUpdate()
        {
            MovePlayer(moveInput);
        }

        private void InvokePauseEvent() => OnPlayerPaused?.Invoke();

        private void RotatePlayer(Vector2 input)
        {
            if (input == Vector2.zero) return;

            float zRotation = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg - 90;
            Quaternion finalRotation = Quaternion.Euler(0, 0, zRotation).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, finalRotation, rotateSpeed * Time.deltaTime);
        }

        private void MovePlayer(Vector2 input)
        {
            Vector2 movement = input.normalized * walkSpeed;
            rb2d.velocity = movement;
        }
    }
}
