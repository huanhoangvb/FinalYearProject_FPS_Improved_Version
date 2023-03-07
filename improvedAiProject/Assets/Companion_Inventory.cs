using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion_Inventory : MonoBehaviour
{
    private int bulletStored;

    // Start is called before the first frame update
    void Start()
    {
        bulletStored = 0;
    }


    public void addResource(string resourceName, int amount)
    {
        bulletStored += amount;
    }

    public int depleteResource() {
        int bulletRep = bulletStored;
        bulletStored = 0;
        return bulletRep;
    }
}
