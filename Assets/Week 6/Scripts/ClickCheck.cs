using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCheck : MonoBehaviour
{

    SceneLoader loader;

    private void Start()
    {
        loader = GetComponent<SceneLoader>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            loader.LoadNextScene();

        }
    }

}
