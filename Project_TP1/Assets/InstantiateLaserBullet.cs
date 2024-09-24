using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLaserBullet : MonoBehaviour
{
    [SerializeField] private GameObject _escapingBulletToInstantiate;
    [SerializeField] private Transform _bulletTransform;
    [SerializeField] private float _minSpawnInterval = 1f;
    [SerializeField] private float _maxSpawnInterval = 3f;
    private float _timer;
    private float _spawnBulletInterval;

    void Start()
    {
        _spawnBulletInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnBulletInterval)
        {
            Shoot();
            _timer = 0f;

            _spawnBulletInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
        }
    }

    void Shoot()
    {
        GameObject CanonBullet = Instantiate(_escapingBulletToInstantiate, _bulletTransform.position, _bulletTransform.rotation);

        GoUpScript goUpScript = CanonBullet.GetComponent<GoUpScript>();
        if (goUpScript != null)
        {
            goUpScript.MoveUpFunction();
        }
    }
}
