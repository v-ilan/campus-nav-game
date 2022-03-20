using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  script to show and hide object from fixed distance
 */

public class PointManager : MonoBehaviour
{
    public GameObject ARCam; //Main AR camera in our scene
    public GameObject Obj; // The object which we want to show when the user reach the point
    internal float dist; // The current distance between AR camera and object
    public float Range = 10; // The range of show the object

    private void Awake()
    {
        Obj.SetActive(false);
        if (ARCam == null)
        {
            ARCam = GameObject.Find("AR Camera");
        }
    }

    private void FixedUpdate()
    {
        if (ARCam != null)
        {
            dist = Vector3.Distance(transform.position, ARCam.transform.position);
            if (dist < Range)
            {
                Obj.SetActive(true);
            }

            if (dist > Range)
            {
                Obj.SetActive(false);
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, Range);
        UnityEditor.Handles.Label(transform.position, gameObject.name + "\nRange = " + Range);
    }
#endif
}