using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;

public class TeleportMenu : MonoBehaviour
{
    public GameObject ARCam;
    public ARSessionOrigin myARSessionOrigin;
    public Transform[] teleportPos;

    private void Awake()
    {
        if (ARCam == null)
        {
            ARCam = GameObject.Find("AR Camera");
        }
        if (myARSessionOrigin == null)
        {
            myARSessionOrigin = GetComponent<ARSessionOrigin>();
        }
    }

    public void Teleport(int teleIndex)
    {
        myARSessionOrigin.MakeContentAppearAt(teleportPos[teleIndex].transform, ARCam.transform.position, Quaternion.Inverse(ARCam.transform.rotation));
    }
}
