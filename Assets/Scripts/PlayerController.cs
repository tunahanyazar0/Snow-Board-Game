using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float valueTorq = 2.1f;

    public float jumpAmount = 1f;
    bool inAir = false;

    SurfaceEffector2D surfaceEffector2D;

    [SerializeField] float BoostSpeed = 20f;
    [SerializeField] float BaseSpeed = 11f;

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            // hareket etme olayları
            AddingTorque();
            RespondToBoost();
        }
    }

    private void RespondToBoost()
    {
        // yukarı ok tuşuna basılınca hızlanacak!
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = BoostSpeed;
        }
        else
            surfaceEffector2D.speed = BaseSpeed;
    }

    private void AddingTorque()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(valueTorq);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // - yönde torq!
            rb2d.AddTorque(-valueTorq);
        }

        // jumping
        // zıplama , spin atma gibi işlemler rigidbody ğzerinden yapılır
        if (Input.GetKey(KeyCode.Space) && inAir == false)
        {
            inAir = true;
            rb2d.AddForce(Vector2.up * jumpAmount, ForceMode2D.Force);
        }
    }

    public void disableControls()
    {
        canMove = false;
    }

    public  void AirControls()
    {
        if (inAir)
        {
            inAir = false;
        }
        
    }
}
