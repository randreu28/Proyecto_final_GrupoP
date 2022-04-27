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
    private bool isSprinting = false;

    private Vector3 walkVec;
    private Vector3 sprintVec;
    private Quaternion rotationCam;

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        rotationCam = cam.transform.rotation; //For making the player move on the direction it's facing
        rotationCam.eulerAngles = new Vector3(0, rotationCam.eulerAngles.y, rotationCam.eulerAngles.z); //Making it so it doesnt affect the z axis
        if (isSprinting)
        {
            _controller.Move((rotationCam * sprintVec));
        }
        else
        {
            _controller.Move((rotationCam * walkVec));
        }

    }

    void OnMove(InputValue input)
    {
        Vector2 moveInput = input.Get<Vector2>();
        walkVec = new Vector3(moveInput.x * walkSpeed, 0, moveInput.y * walkSpeed);
        sprintVec = new Vector3(moveInput.x * sprintSpeed, 0, moveInput.y * sprintSpeed);
    }

    void OnSprint(InputValue input)
    {
        if (input.isPressed)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }
}
