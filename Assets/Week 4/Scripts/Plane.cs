using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Plane : MonoBehaviour
{

    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector3 lastPosition; //camera returns vector3!
    LineRenderer lineRenderer;
    SpriteRenderer spriteRenderer;
    Vector2 currentPosition;
    Rigidbody2D rigidbody;
    public float speed = 1f;
    public AnimationCurve landing;
    float landingTimer;
    bool isLanding = false;
    int randomColor;

    float destructionTimer = 0;

    public GameObject ownTrigger; // <-- this isnt a good method

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        //randomColor = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        // ^ this changes the sprite color, but it doesn't appear in-game unless you adjust the inspector


        randomColor = Random.Range(1, 3);

        if (randomColor == 1)
        {
            spriteRenderer.color = Color.blue;
        }
        else if (randomColor == 2)
        {
            spriteRenderer.color = Color.red;
        } 
        else
        {
            spriteRenderer.color = Color.black;
        }

    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(currentPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        // should work without V2 cast, its just to make sure
        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(currentPosition, lastPosition) > newPointThreshold)
        {
            points.Add(currentPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPosition);
            lastPosition = currentPosition;
        }



    }

    private void FixedUpdate()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);
        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x,direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }

        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);

    }

    private void Update()
    {

        if(isLanding)
        {
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if (transform.localScale.z < 0.1f)
            {
                Debug.Log("Plane landed - Score increased!");
                Destroy(gameObject);
            }

            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
        }

        if(points.Count > 0)
        {

            if (Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Runway")
        {
            Debug.Log("Trigger!");
            isLanding = true;

        }

        if (collision.gameObject.name == "A" && collision.gameObject != ownTrigger.gameObject)
        {
            Debug.Log("Proximity warning!");
            //isLanding = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        destructionTimer = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "A" && collision.gameObject != ownTrigger.gameObject)
        {
            destructionTimer += Time.deltaTime;

            if (destructionTimer > 2)
            {
                Debug.Log("Too close - plane destroyed!");
                Destroy(gameObject);

            }

        }
    }




}
