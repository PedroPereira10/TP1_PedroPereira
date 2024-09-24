using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUpScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 5f;
    private float _destructionTime;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _destructionTime = Time.time + 10f;
        MoveUpFunction();
    }
    private void Update()
    {
        if (Time.time >= _destructionTime)
        {
            Destroy(gameObject);
        }
    }
    public void MoveUpFunction()
    {
        _rigidbody.velocity = transform.up * _speed;
    }
}
