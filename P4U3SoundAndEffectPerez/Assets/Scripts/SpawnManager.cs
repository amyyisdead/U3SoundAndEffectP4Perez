using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obsticalPrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    private int randomObstical;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstical", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstical()
    {
        if (playerControllerScript.gameOver == false)
        {
            randomObstical = Random.Range(0, obsticalPrefabs.Length);
            Instantiate(obsticalPrefabs[randomObstical], spawnPos, obsticalPrefabs[randomObstical].transform.rotation);
        }
        
    }
}
