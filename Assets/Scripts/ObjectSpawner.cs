using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] trianglePrefabs;
    private Vector3 spawnObstaclePosition;
    private int distanceToSpawn = 120;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToHorizon = Vector3.Distance(player.transform.position, spawnObstaclePosition);
        
        if(distanceToHorizon < distanceToSpawn)
        {
            //spawn triangles
            SpawnTriangles();
        }
    }

    void SpawnTriangles()
    {
        int randomPrefab = Random.Range(0, trianglePrefabs.Length);

        //set a place to spawn the obstacles
        spawnObstaclePosition = new Vector3(0, 0, spawnObstaclePosition.z + 30);

        //spawn the obstacles
        Instantiate(trianglePrefabs[randomPrefab], spawnObstaclePosition, Quaternion.identity);
        StartCoroutine(WaitToDestroy(7f));
    }

    IEnumerator WaitToDestroy(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
    }
}
