using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPivot : MonoBehaviour
{
    [SerializeField] private float _minAngle = -50;
    [SerializeField] private float _maxAngle = 50;
    [SerializeField] private float _rotationSpeed = 2;
    [SerializeField] private float _startAngle = 45;

    private bool rotatingForward = true;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, _startAngle);
    }

    
    void Update()
    {
        float currentAngle = transform.rotation.eulerAngles.z;

        if (currentAngle > 180)
        {
            currentAngle -= 360; 
        }

        if (rotatingForward)
        {
            currentAngle += _rotationSpeed * Time.deltaTime;

            if (currentAngle > _maxAngle)
            {
                rotatingForward = false;
            }
        }

        else
        { 
            currentAngle -= _rotationSpeed * Time.deltaTime;

            if (currentAngle <= _minAngle)
            {
                rotatingForward = true;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
    }
}
