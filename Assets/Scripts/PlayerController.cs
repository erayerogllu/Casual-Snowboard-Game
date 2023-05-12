using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount;
    [SerializeField] float boostSpeed;
    [SerializeField] float normalSpeed;
    [SerializeField] float stopSpeed;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    
  

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }


    public void DisableControls()
    {
        canMove = false;
    }


   void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        
        else if(Input.GetKey(KeyCode.S))
        {
            surfaceEffector2D.speed = stopSpeed;
        }
        
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    
    
    
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
    }
}
