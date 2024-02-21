using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public GameObject kickoff;
    public Rigidbody2D rb;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Goal!");
        Controller.score += 1;
        transform.position = kickoff.transform.position;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        scoreManager.UpdateScore(Controller.score);
    }

}
