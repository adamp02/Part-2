using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject plane;
    public float timerValue;
    public float timerTarget;

    // Start is called before the first frame update
    void Start()
    {
        timerTarget = Random.Range(2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        timerValue += Time.deltaTime;

        if (timerValue > timerTarget)
        {
            Instantiate(plane);
            timerValue = 0;
            timerTarget = Random.Range(2, 5);


        }
    }
 

}
