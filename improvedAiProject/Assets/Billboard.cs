using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>().transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(cam.forward + transform.position);
    }
}
