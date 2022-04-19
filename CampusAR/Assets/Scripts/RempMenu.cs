using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;

public class RempMenu : MonoBehaviour
{
    public GameObject ARCam;
    public Transform[] teleportPos;

    private void Awake()
    {
        if (ARCam == null)
        {
            ARCam = GameObject.Find("AR Camera");
        }
    }

    public void Remap(int teleIndex)
    {
        teleportPos[teleIndex].transform.position = ARCam.transform.position;
    }
}
