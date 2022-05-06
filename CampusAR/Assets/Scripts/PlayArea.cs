using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    public GameObject Obj;
    public GameObject PrevCollider;
    public GameObject NextCollider;

    private void Awake()
    {
        Obj.SetActive(false);
        NextCollider.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Obj.SetActive(true);
        PrevCollider.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        Obj.SetActive(false);
        NextCollider.SetActive(true);
    }
}
