using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

    public int obstacleCount = 5;
    public GameObject obstaclePrefab;
    public float spawnRate = 0.1f;
    public float obstacleMin = -1f;
    public float obstacleMax = 3.5f;

    private GameObject[] obstacles;
    private float timeSinceLastSpawned = 3;
    private int currObstacle = 0;

	// Use this for initialization
	void Start ()
    {
        obstacles = new GameObject[obstacleCount];

        for(int i = 0; i < obstacleCount; i++)
        {
            obstacles[i] = (GameObject)Instantiate(obstaclePrefab, new Vector2(-15f, -25f), Quaternion.identity);

        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if(timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(obstacleMin, obstacleMax);
            float spawnXPosition = Random.Range(3, 6);
            obstacles[currObstacle].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currObstacle++;

            if(currObstacle >= obstacleCount)
            {
                currObstacle = 0;
            }
        }
	}
}
