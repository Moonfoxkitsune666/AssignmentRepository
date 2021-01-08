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



}