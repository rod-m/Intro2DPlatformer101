using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int health = 100;
    public int score = 0;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    private GameObject _player;
    void Start()
    {
        AddHealth(-10);
        AddScore(100);
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    public void AddHealth(int h)
    {
        health += h;
        healthText.text = $"Health {health}";
        PlayerHealthCheck();
    }

    private void PlayerHealthCheck()
    {
        if (health <= 0)
        {
            _player.SendMessage("ReSpawn");
            health = 100;
            AddHealth(0);
        }
    }
    public void AddScore(int h)
    {
        score += h;
        scoreText.text = $"Score {score}";
    }
}
