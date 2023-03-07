using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombie;
    private float y = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnZombie",0,4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 getRandomPositionLeftHouse()
    {
        float x = Random.Range(46, 50);

        float z = Random.Range(-44, -33);

        return new Vector3(x, y, z);
    }

    Vector3 getRandomPositionRightHouse()
    {
        float x = Random.Range(32, 25);
        float z = Random.Range(-48, -33);

        return new Vector3(x, y, z);
    }


    Vector3 getRandomPosition() {
        int rand = Random.Range(0, 2);
        if (rand == 1)
            return getRandomPositionLeftHouse();
        else
            return getRandomPositionRightHouse();
    }

    void spawnZombie()
    {
        int numberOfZombie = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(numberOfZombie);
        if(numberOfZombie < 3)
        {
            Instantiate(zombie, getRandomPosition(), Quaternion.identity);
        }

    }
}
