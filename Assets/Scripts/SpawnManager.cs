using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject ballPrefab;
    private Vector3 spawnPos;
    private float spawnRangeX = 1;
    private float spawnPosZ = 10;
    private float startDelay = 2;
    private float repeatRate = 2;
    private float startDelay2 = 5;
    private float repeatRate2 = 10;
    public PlayerController playerController;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
        InvokeRepeating("SpawnBalls", startDelay2, repeatRate2);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        if (playerController.isGameOver == false && gameManager.isGameActive == true)
        {
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0f, spawnPosZ);
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }

    void SpawnBalls()
    {
        if (playerController.isGameOver == false && gameManager.isGameActive == true)
        {
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPosZ);
            Instantiate(ballPrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
