using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    public GameObject sword;

    public void SpawnSword()
    {
        Instantiate(sword);
    }
}
