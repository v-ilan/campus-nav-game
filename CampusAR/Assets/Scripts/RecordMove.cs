using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecordMove : MonoBehaviour
{
    public int samplingTime = 1; // sample time in sec
    public string outputFileName = "recordedPath";

    private StreamWriter _sw;

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
        _sw.WriteLine("t {0} x {1} z {2} y {3} fx {4} fz {5} fy {6}",
           Time.time, transform.position.x, transform.position.z, transform.forward.x, transform.forward.z);
    }
}