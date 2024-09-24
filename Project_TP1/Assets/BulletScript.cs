using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject _bulletToInstantiate;
    private float _timer;
    [SerializeField]  private float _fireRate = 0.5f;
    [SerializeField]  private Transform _bulletTransform;

    void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _timer >= _fireRate)
        {
            
            Shoot();
            _timer = 0;
        }

        void Shoot()
        {
            GameObject ShipBullet = Instantiate(_bulletToInstantiate, _bulletTransform.position, _bulletTransform.rotation);

            GoUpScript goUpScript = ShipBullet.GetComponent<GoUpScript>();
            if (goUpScript != null)
            { 
                goUpScript.MoveUpFunction();
            }
        }
    }

}
