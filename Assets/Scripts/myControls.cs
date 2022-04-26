using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class myControls : MonoBehaviour
{
    private CharacterController _controller;

    [Range(0, 1)]
    public float walkSpeed;

    [Range(0, 1)]
    public float sprintSpeed;

    private Vector3 movementVec;

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        _controller.Move(movementVec);
    }

    void OnMove(InputValue input)
    {
        Vector2 moveInput = input.Get<Vector2>();
        movementVec = new Vector3(moveInput.x * walkSpeed, 0, moveInput.y * walkSpeed);
    }
}
