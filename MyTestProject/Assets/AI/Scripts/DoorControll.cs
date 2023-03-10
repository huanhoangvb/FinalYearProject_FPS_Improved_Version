using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControll : MonoBehaviour
{
    public bool open = false;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("Open", true);
        }

    }
}
