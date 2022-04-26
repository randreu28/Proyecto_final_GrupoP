using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class myControls : MonoBehaviour
{
    private CharacterController _controller;
    public GameObject cam;

    [Range(0, 1)]
    public float walkSpeed;

    [Range(0, 1)]
    public float sprintSpeed;

    private Vector3 movementVec;
    private Quaternion rotationCam;

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        _controller.Move(movementVec);
        rotationCam = cam.transform.rotation;
    }

    void OnMove(InputValue input)
    {
        Vector2 moveInput = input.Get<Vector2>();
        moveInput =  rotationCam * moveInput; //For making the player move on the direction it's facing
        movementVec = new Vector3(moveInput.x * walkSpeed, 0, moveInput.y * walkSpeed);
    }
}
