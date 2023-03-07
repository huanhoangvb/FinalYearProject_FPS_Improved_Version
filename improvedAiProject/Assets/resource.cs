using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource : MonoBehaviour
{
    public void destroyResource() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectsWithTag("Weapon")[0].GetComponent<GunScript>().bulletsIHave += 30;
            destroyResource();
        }
    }
}
