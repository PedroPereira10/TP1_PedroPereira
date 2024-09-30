using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (GetComponent<ShipBulletScript>() != null && other.GetComponent<EscapingShipScript>() != null)
        {
            Destroy(other.gameObject);
            gameManager.ShipDestroyed();
        }

        if (GetComponent<ShipScript2>() != null && other.GetComponent<LaserBulletScript>() != null)
        {
            Destroy(other.gameObject);
            gameManager.LifeLost();
        }
    }
}
