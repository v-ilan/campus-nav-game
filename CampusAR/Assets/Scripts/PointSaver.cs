using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PointSaver : MonoBehaviour
{
    internal static int counter;
    static string txt;
    static GameObject gos;
    public GameObject ARCam;

    public void SavePoint()
    {
        gos = GameObject.Find("Point0");
        if (gos == null)
        {
            counter = 0;
        }
        GameObject GO = Instantiate(Resources.Load("Point") as GameObject);
        GO.transform.position = ARCam.transform.position;
        GO.transform.localEulerAngles = ARCam.transform.localEulerAngles;
        GO.name = "Point" + counter;

        string Pointcharactercis = "N:" + GO.name + "_PX:" + GO.transform.position.x + "_PY:" + GO.transform.position.y + "_PZ:" + GO.transform.position.z +
        "_RX:" + GO.transform.eulerAngles.x + "_RY:" + GO.transform.eulerAngles.y + "_RZ:" + GO.transform.eulerAngles.z + "_SX:" +
        GO.transform.localScale.x + "_SY:" + GO.transform.localScale.y + "_SZ:" + GO.transform.localScale.z + "kh";
        
        print(Pointcharactercis);
       
        // It will save your file in Android/Data/app name folder/files
        string path = Application.persistentDataPath + "/PointsList.txt";
       
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(Pointcharactercis);
        writer.Close();

        counter++;
    }
}
