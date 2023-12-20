// Code sourced from Dilmer Valecillos, https://youtu.be/aKYLOsz5jFU?si=af0_vGCLmaG3cEwd&t=694
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;

    public void CloneObject()
    {
        var newObject = Instantiate(gameObject);
        newObject.transform.parent = gameObject.transform.parent;
        newObject.transform.position = gameObject.transform.position + offset;
        gameObject.SetActive(false);
    }
}
