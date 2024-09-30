using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    [SerializeField] private GameObject _shieldPrefab;  
    [SerializeField] private Transform _ship;           
    [SerializeField] private float _shieldDuration = 2f; 
    [SerializeField] private float _fadeSpeed = 1f;      

    private GameObject _currentShield; 
    private SpriteRenderer _shieldSpriteRenderer; 

    private bool _fadingIn = false;
    private bool _fadingOut = false;
    private float _shieldTime = 0;

    void Update()
    {
        if (_currentShield != null)
        {
            
            if (_fadingIn)
            {
                Color shieldColor = _shieldSpriteRenderer.color;
                if (shieldColor.a < 1f)
                {
                    shieldColor.a += Time.deltaTime * _fadeSpeed; 
                    _shieldSpriteRenderer.color = shieldColor;
                }
                else
                {
                    _fadingIn = false; 
                }
            }

            
            if (_fadingOut)
            {
                Color shieldColor = _shieldSpriteRenderer.color;
                if (shieldColor.a > 0)
                {
                    shieldColor.a -= Time.deltaTime * _fadeSpeed; 
                    _shieldSpriteRenderer.color = shieldColor;
                }
                else
                {
                    _fadingOut = false; 
                    Destroy(_currentShield); 
                }
            }

            
            _shieldTime += Time.deltaTime;
            if (_shieldTime >= _shieldDuration && !_fadingOut)
            {
                StartFadeOut();
            }

            _currentShield.transform.position = _ship.position;
        }
    }


    public void DamageTaken(Vector3 bulletPosition)
    {
        if (_currentShield == null) 
        {
            _currentShield = Instantiate(_shieldPrefab, _ship.position, Quaternion.identity);
            _currentShield.transform.localScale = _ship.localScale;
            _currentShield.transform.SetParent(_ship);
            _shieldSpriteRenderer = _currentShield.GetComponent<SpriteRenderer>();

            if (_shieldSpriteRenderer == null)
            {
                return;
            } 

            Vector3 directionBullet = bulletPosition - _ship.position;
            _currentShield.transform.LookAt(bulletPosition, Vector3.forward);
            _currentShield.transform.rotation = Quaternion.Euler(0, 0, _currentShield.transform.eulerAngles.z);

            StartFadeIn();
        }
    }

    private void StartFadeIn()
    {
        _fadingIn = true;
        _fadingOut = false;
        _shieldTime = 0;

        Color shieldColor = _shieldSpriteRenderer.color;
        shieldColor.a = 0f; 
        _shieldSpriteRenderer.color = shieldColor;
    }

    
    private void StartFadeOut()
    {
        _fadingOut = true;
        _fadingIn = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LaserBullet(Clone)") 
        {
            Vector3 bulletPosition = collision.transform.position;

            DamageTaken(bulletPosition);

            Destroy(collision.gameObject);
        }
    }
}
