using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using System.IO;
using System;

public class PointMaker : MonoBehaviour
{
#if UNITY_EDITOR

    internal static int counter;
    static string txt;
    internal static string[] lines;
    static GameObject gos;

    [MenuItem("ARLocation/Create New Point")]
    static void PointMake()
    {
        gos = GameObject.Find("Point0");
        if (gos == null)
        {
            counter = 0;
        }
        GameObject GO = Instantiate(Resources.Load("Point") as GameObject);
        GO.transform.position = new Vector3(0, 0, 0);
        GO.name = "Point" + counter;
        counter++;
    }

    [MenuItem("ARLocation/Read file")]
    static void ReadString()
    {
        string path = "Assets/Resources/PointsList.txt";
        StreamReader reader = new StreamReader(path);
        txt = reader.ReadToEnd().ToString();
        lines = txt.Split(new string[] { "kh" }, StringSplitOptions.None);

        for (int i = 0; i < lines.Length - 1; i++)
        {
            if (lines[i].Contains("kh"))
            {
                lines[i] = lines[i].Remove(lines[i].Length - 2, 2);
            }
            print(lines[i]);

            if (!lines[i].Contains(" "))
            {
                StartProcess(lines[i]);
            }
        }
        reader.Close();
    }

    private static void StartProcess(string s)
    {
        var Obj = StringToVector3(s);
        string S = Vector3ToString(Obj);
        GameObject GO = Instantiate(Resources.Load("Point") as GameObject);
        GO.transform.position = new Vector3(Obj.PosX, Obj.PosY, Obj.PosZ);
        GO.transform.localEulerAngles = new Vector3(Obj.RotX, Obj.RotY, Obj.RotZ);
        GO.name = Obj.Name;
    }

    private static ObjectTransform StringToVector3(string s)
    {
        string[] ArrayS = s.Split('_');
        ObjectTransform objectTransform = new ObjectTransform();
        objectTransform.Name = ArrayS[0].Remove(0, 2);

        if (objectTransform.Name.Contains("N:"))
        {
            objectTransform.Name = objectTransform.Name.Replace("N:", "");
        }

        if (objectTransform.Name.Contains(":"))
        {
            objectTransform.Name = objectTransform.Name.Replace(":", "");
        }
        objectTransform.PosX = float.Parse(ArrayS[1].Remove(0, 3));
        objectTransform.PosY = float.Parse(ArrayS[2].Remove(0, 3));
        objectTransform.PosZ = float.Parse(ArrayS[3].Remove(0, 3));
        objectTransform.RotX = float.Parse(ArrayS[4].Remove(0, 3));
        objectTransform.RotY = float.Parse(ArrayS[5].Remove(0, 3));
        objectTransform.RotZ = float.Parse(ArrayS[6].Remove(0, 3));
        objectTransform.ScaX = float.Parse(ArrayS[7].Remove(0, 3));
        objectTransform.ScaY = float.Parse(ArrayS[8].Remove(0, 3));
        objectTransform.ScaZ = float.Parse(ArrayS[9].Remove(0, 3));
        return objectTransform;
    }

    private static string Vector3ToString(ObjectTransform objectTransform)
    {
        string Name = "N:" + objectTransform.Name;
        string PosX = "PX:" + objectTransform.PosX;
        string PosY = "PY:" + objectTransform.PosY;
        string PosZ = "PZ:" + objectTransform.PosZ;
        string RotX = "RX:" + objectTransform.RotX;
        string RotY = "RY:" + objectTransform.RotY;
        string RotZ = "RZ:" + objectTransform.RotZ;
        string ScaX = "SX:" + objectTransform.ScaX;
        string ScaY = "SY:" + objectTransform.ScaY;
        string ScaZ = "SZ:" + objectTransform.ScaZ;
        return Name + "-" + PosX + "-" + PosY + "-" + PosZ + "-" + RotX + "-" + RotY + "-" + RotZ + "-" + ScaX + "-" + ScaY + "-" + ScaZ;
    }

    [System.Serializable]

    public struct ObjectTransform
    {
        public string Name;
        public float PosX;
        public float PosY;
        public float PosZ;
        public float RotX;
        public float RotY;
        public float RotZ;
        public float ScaX;
        public float ScaY;
        public float ScaZ;
    }
#endif
}