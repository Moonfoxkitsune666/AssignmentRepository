using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShredder : MonoBehaviour
{
    [SerializeField] GameObject obstacleBullet;
    [SerializeField] int scoreValue = 5;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        
        if (obstacleBullet)
        {
            print("Deleted Bullet");
            Destroy(otherObject.gameObject);
        }
        else
        {
            print("Added point");
            Destroy(otherObject.gameObject);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
        }
    }
}
