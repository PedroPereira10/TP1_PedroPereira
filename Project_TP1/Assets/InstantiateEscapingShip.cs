using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEscapingShip : MonoBehaviour
{
    [SerializeField] private GameObject _escapingShiptoInstantiate;
    [SerializeField] private float _spawnShipInterval;
    private float _timer;
    [SerializeField] private float _minY = 0f;
    [SerializeField] private float _maxY = 10f;
    void Start()
    {
        _timer = Random.Range(0f, _spawnShipInterval);
    }
    void Update()
    {
        _timer += Time.deltaTime; 

        if (_timer >= _spawnShipInterval)
        {
            float randomY = Random.Range(_minY, _maxY);
            Vector3 randomPosition = new Vector3 (-20,randomY, 0f);

            GameObject newEscapingShip = Instantiate(_escapingShiptoInstantiate, randomPosition, Quaternion.identity);

            GoRightScript newEscapingShipScript = newEscapingShip.GetComponent<GoRightScript>();
            newEscapingShipScript.MoveRightFunction();

            _timer = 0f;
            _spawnShipInterval = Random.Range(1f, 3f);
            
        }
    }
}
