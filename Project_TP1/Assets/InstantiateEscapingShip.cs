using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEscapingShip : MonoBehaviour
{
    [SerializeField] private GameObject _escapingShiptoInstantiate;
    [SerializeField] private float _spawnShipInterval;
    [SerializeField] private Transform _referenceObject;
    private float _timer;
    void Start()
    {
        _timer = Random.Range(0f, _spawnShipInterval);
    }
    void Update()
    {
        _timer += Time.deltaTime; 

        if (_timer >= _spawnShipInterval)
        {
            float randomY = Random.Range(0f, Screen.height);

            Vector3 screenPosition = new Vector3(0, randomY, Camera.main.nearClipPlane);
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, randomY, Camera.main.nearClipPlane));

            spawnPosition.z = 0; 
            spawnPosition += _referenceObject.position;

            GameObject newEscapingShip = Instantiate(_escapingShiptoInstantiate, spawnPosition, Quaternion.identity);

            GoRightScript newEscapingShipScript = newEscapingShip.GetComponent<GoRightScript>();
            newEscapingShipScript.MoveRightFunction();

            _timer = 0f;
            _spawnShipInterval = Random.Range(1f, 3f);
            
        }
    }
}
