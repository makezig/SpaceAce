using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPrefabs; // Allows putting spawnable prefabs in
    private float spawnRangeX = 20;
    private float spawnPosZ = 60; // Where to spawn on z-axis

    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    private GameManager gameManager;

    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start spawning Animals randomly
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    void SpawnRandomAnimal()
    {
        // Randomly generate spawn position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int spawnIndex = Random.Range(0, spawnPrefabs.Length); // Randomly generate animal index

        // Spawn the animal based on index and position
        if (gameManager.gameOver == false)
        {
            Instantiate(spawnPrefabs[spawnIndex], spawnPos, spawnPrefabs[spawnIndex].transform.rotation);
        }
    }
}
