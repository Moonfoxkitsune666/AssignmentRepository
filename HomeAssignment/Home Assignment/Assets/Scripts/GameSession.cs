using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    int health = 50;

    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHealth()
    {
        return health;
    }

    public void GameScore(int scoreValue)
    {

        score += scoreValue;
        print(score);

        if(score == 100)
        {
            FindObjectOfType<Level>().LoadGameWin();
        }
    }

    public void PlayerHealth(int healthValue)
    {
        health = healthValue;
        print(health);
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
