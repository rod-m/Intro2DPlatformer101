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
    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        AddHealth(0);
        AddScore(0);
    }

    private void PlayerHealthCheck()
    {
        if (health <= 0)
        {
            player.SendMessage("ReSpawn");
            health = 100;
            AddHealth(0);
        }
    }
    public void AddHealth(int h)
    {
        health += h;
        healthText.text = $"Health {health}";
        PlayerHealthCheck();
    }
    public void AddScore(int h)
    {
        score += h;
        scoreText.text = $"Score {score}";
    }
   
}
