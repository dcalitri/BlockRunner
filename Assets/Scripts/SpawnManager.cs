using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject ballPrefab;
    private Vector3 spawnPos;
    private float spawnRangeX = 2;
    private float spawnPosZ = 10;
    private float startDelay = 2;
    private float repeatRate = 2;
    private float startDelay2 = 5;
    private float repeatRate2 = 10;
    private PlayerController playerController;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
        InvokeRepeating("SpawnBalls", startDelay2, repeatRate2);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        if (playerController.isGameOver == false && gameManager.isGameActive == true)
        {
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPosZ);
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }

    void SpawnBalls()
    {
        if (playerController.isGameOver == false)
        {
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPosZ);
            Instantiate(ballPrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
