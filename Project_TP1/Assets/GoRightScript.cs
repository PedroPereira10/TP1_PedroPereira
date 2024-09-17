using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoRightScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _destructionTime;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _destructionTime = Time.time + 10f;
    }
    private void Update()
    {
        if (Time.time >= _destructionTime)
        { 
            Destroy(gameObject);
        }
    }
    
    public void MoveRightFunction()
    {
        _rigidbody.velocity = new Vector3(5f, 0f, 0f);
    }
}
