using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int _totalShips = 20;
    public int _lives = 5;
    private int _destroyedShips = 0;

    public Text _destroyedShipsText;
    public Text _livesText;
    public GameObject _gameOverScreen;
    public GameObject _victoryScreen;

    void Start()
    {
        UpdateUI();
    }


    public void ShipDestroyed()
    {
        _destroyedShips++;
        UpdateUI();
        if (_destroyedShips >= _totalShips)
        {
            Victory();
        }
    }


    public void LifeLost()
    {
        _lives--;
        UpdateUI();
        if (_lives <= 0)
        {
            GameOver();
        }
    }


    void UpdateUI()
    {
        _destroyedShipsText.text = "" + _destroyedShips;
        _livesText.text = "" + _lives;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
         Time.timeScale = 1;
    }

    public void Victory()
    {
        _victoryScreen.SetActive(true);
        Time.timeScale = 1;
    }
}
