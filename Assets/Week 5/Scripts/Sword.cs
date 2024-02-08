using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    Rigidbody2D rigidbody;
    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessageUpwards("TakeDamage", 5, SendMessageOptions.DontRequireReceiver);
    }

}
