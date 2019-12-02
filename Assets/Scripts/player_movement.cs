﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public float Speed = 5.0f;
    public float Gravity = 1f;
    public float RotationSpeed = 7.0f;
    public float JumpSpeed = 1.0f;
    public float RunSpeed = 5.0f;

    private CharacterController C_Controller;
    private Vector3 moveDir = Vector3.zero;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        C_Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (C_Controller.isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= RunSpeed;

            if (Input.GetButton("Jump"))
            {
                moveDir.y = JumpSpeed;
            }
        }
        
        if (C_Controller.isGrounded && !Input.GetKey(KeyCode.LeftShift))
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= Speed;

            if (Input.GetButton("Jump"))
            {
                moveDir.y = JumpSpeed;
            }
        }

        moveDir.y -= Gravity * Time.deltaTime;
        C_Controller.Move(moveDir * Time.deltaTime);

        yaw = RotationSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0.0f, yaw, 0.0f), Space.World);
    }
}
