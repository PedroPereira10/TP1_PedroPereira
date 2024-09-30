using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();  
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<EscapingShipScript>() != null)
        {
            Destroy(other.gameObject);  
            gameManager.GameOver();  
        }
    }
}
