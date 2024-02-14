using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRes : MonoBehaviour
{
    public void SetResolution169()
    {

        Screen.SetResolution(1280, 720, false); //720p 16:9 res
        Debug.Log("Resolution set to 16:9 [720p - 1280x720]");
    }

    public void SetResolutionFullHD()
    {

        Screen.SetResolution(1920, 1080, false);
        Debug.Log("Resolution set to Full HD [1080p - 1920x1080]");
    }
}
