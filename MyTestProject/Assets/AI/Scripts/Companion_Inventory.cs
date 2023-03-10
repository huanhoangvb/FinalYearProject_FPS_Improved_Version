using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion_Inventory : MonoBehaviour
{
    private int bulletStored = 0;

    public void addResource(int amount)
    {
        bulletStored += amount;
    }

    public int depleteResource() {
        int bulletRep = bulletStored;
        bulletStored = 0;
        return bulletRep;
    }
}
