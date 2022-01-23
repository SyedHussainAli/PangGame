using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectPrefabs;
    public GameObject bigObjectPF;
    private float spawnDelay = 2;
    private float spawnInterval = 3f;
    private float bigSpawnInterval = 5;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        InvokeRepeating("BigSpawnObjects", spawnDelay, bigSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void SpawnObjects()
    {
        if (!playerControllerScript.gameOver)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(-10, 11), 20, 0);
            Instantiate(objectPrefabs, spawnLocation, objectPrefabs.transform.rotation);
        }
      

    }
    void BigSpawnObjects()
    {
        if (!playerControllerScript.gameOver) 
        {
            Vector3 spawnLocation = new Vector3(Random.Range(-10, 11), 20, 0);
            Instantiate(bigObjectPF, spawnLocation, bigObjectPF.transform.rotation);
        }
       

    }
}
