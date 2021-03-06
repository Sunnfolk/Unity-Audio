﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    // We use Serialize to make the variable appear in the Inspector
    // This allows us to change the variable at runtime 
    [SerializeField] private float _speed = 5f;

    private float _horizontal = 0f;
    private float _vertical = 0f;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private Transform Cam;
    private Vector3 _moveVector;
    private CharacterController _controller;
    // Start is called before the first frame update
    void Start ()
    { 
        Cam = Camera.main.transform;
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Fetch the Raw input from our Movement Axis (-1 to 1)
		_horizontal = Input.GetAxisRaw("Horizontal");
		_vertical = Input.GetAxisRaw("Vertical");

		// Combine the input data into one Vector
		_moveVector = new Vector3(_horizontal,0f, _vertical).normalized;

        if (_moveVector.magnitude >= 0.1f)
        { 
            float targetAngle = Mathf.Atan2(_moveVector.x, _moveVector.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _controller.Move(moveDir * _speed * Time.deltaTime);
        }
    }
}