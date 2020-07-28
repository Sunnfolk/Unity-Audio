using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // We use Serialize to make the variable appear in the Inspector
    // This allows us to change the variable at runtime 
    [SerializeField] private float _speed = 5f;

    private float _horizontal = 0f;
    private float _vertical = 0f;
    private Vector3 _moveVector;

    private CharacterController _controller;
    // Start is called before the first frame update
    void Start ()
    {
        _controller = GetComponent<CharacterController>();
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
            float targetAngle = Mathf.Atan2(_moveVector.x, _moveVector.y);

            _controller.Move(_moveVector * _speed * Time.deltaTime);
        }     
    }

    void FixedUpdate()
    {
        /*// If the Magnitude of the two movement vectors are above 1
        if (_moveVector.magnitude > 1)
        {
            // Remove additional Diagonal speed by normalizing the movement vector (Setting the magnitude back to 1)
            _moveVector = _moveVector.normalized;
        }
        // Set our velocity to be equal to the _moveVector multiplied with our movement speed;
        _rigidBody.velocity = _moveVector * _speed;
        */
    }
}
