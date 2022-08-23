using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] SpawnableObjects;

    public float SpawnTimer;


    private float timeUntilNextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextSpawn = SpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;
        if (timeUntilNextSpawn <= 0)
        {
            GameObject objectToSpawn = SpawnableObjects[Random.Range(0, SpawnableObjects.Length - 1)];
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            timeUntilNextSpawn = SpawnTimer;
        }
    }
}
