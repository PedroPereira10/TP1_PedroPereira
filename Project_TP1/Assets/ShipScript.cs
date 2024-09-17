using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShipScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotation;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] private float _acceleration = 2f;
    [SerializeField] private float _deceleration = 1f;
    [SerializeField] private float _maxSpeed = 7f;
    [SerializeField] private float _currentSpeed = 0f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        ControlMovement();
    }

    void ControlMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            transform.Rotate(Vector3.forward * horizontalInput * _rotation * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _currentSpeed += _acceleration * Time.deltaTime;
            _currentSpeed = Mathf.Clamp(_currentSpeed, 0, _maxSpeed);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            _currentSpeed -= _deceleration * Time.deltaTime;
            _currentSpeed = Mathf.Clamp(_currentSpeed, 0, _maxSpeed);
        }

        else
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, 0, _deceleration * Time.deltaTime);
        }

        _rigidbody.velocity = transform.up * _currentSpeed;
    }
}

