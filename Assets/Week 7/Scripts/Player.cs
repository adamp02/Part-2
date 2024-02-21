using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 5f;
    public float speed = 10f;
    public SpriteRenderer baseColour;

    public Color colorA = Color.white;
    public Color colorB = Color.blue;

    Vector2 direction;
    bool isSelected = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        baseColour = gameObject.GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
      //  direction.x = Input.GetAxis("Horizontal");
      //  direction.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {

        //rb.AddForce(direction * force * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }


    public void Selected(bool isSelected)
    {
        Debug.Log("Selected!");
        baseColour.color = colorB;

        if (isSelected ) 
        { baseColour.color = colorB; }
        else
        {
            baseColour.color = colorA;
        }
    }

    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

}