using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;

public class RecordMove : MonoBehaviour
{
    public int samplingTime = 1; // sample time in sec
    public string outputFileName = "recordedPath";

    private StreamWriter _sw;

    public GameObject ARCam;
    public ARSessionOrigin myARSessionOrigin;

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

    public void OnEnable()
    {
        _sw = System.IO.File.AppendText(Application.persistentDataPath + outputFileName + ".txt");
        InvokeRepeating("SampleNow", 0,  samplingTime);
    }

    public void OnDisable()
    {
        _sw.Close();
        CancelInvoke();
    }

    public void SampleNow()
    {
        _sw.WriteLine("t: {0}, position (x,y,z): {1}  rotation: {2}", Time.time, ARCam.transform.position - myARSessionOrigin.transform.position, ARCam.transform.rotation * Quaternion.Inverse(myARSessionOrigin.transform.rotation));
    }
}