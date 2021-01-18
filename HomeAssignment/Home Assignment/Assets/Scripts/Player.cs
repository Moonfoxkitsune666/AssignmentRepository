using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.7f;
    [SerializeField] float health = 50f;
    [SerializeField] AudioClip impactSound;
    [SerializeField] [Range(0, 1)] float impactSoundVolume = 0.7f;

    float xMin, xMax, yMin, yMax;
  
    void Start()
    {
        SetUpMoveBoundaries();
    }

  
    void Update()
    {
        Move();
    }
  
    private void SetUpMoveBoundaries()
    {
        
        Camera gameCamera = Camera.main;

  
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

       
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

    
    private void Move()
    {
      
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

       
        var newXPos = transform.position.x + deltaX;
        
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);
       
        this.transform.position = new Vector2(newXPos, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //Gets the damage dealer class from the object
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        //If there is no dmgDealer in obstacle/bullet end method 
        if (!dmgDealer)
        {
            return;
        }

        RegisterHit(dmgDealer);
    }

    private void RegisterHit(DamageDealer dmgDealer)
    {
        //Reduce Health by Damage Given
        health -= dmgDealer.GetDamage();
        AudioSource.PlayClipAtPoint(impactSound, Camera.main.transform.position, impactSoundVolume);

        //If Player Health is equal of lower than 0, Player dies
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}