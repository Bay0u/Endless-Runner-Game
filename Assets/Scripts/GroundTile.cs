using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public GameObject obstaclePrefab1;
    public GameObject obstaclePrefab2;

    public void SpawnObstacle()
    {
        int numberofObistacles = Random.Range(1, 3);
        for (int i = 0; i < numberofObistacles; i++)
        {
            //random point
            int obstacleSpawnIndex = Random.Range(2, 8);
            if (obstacleSpawnIndex >= 2 && obstacleSpawnIndex <= 4)
            {
                Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
                Instantiate(obstaclePrefab1, spawnPoint.position, Quaternion.identity, transform);

            }
            if (obstacleSpawnIndex > 4 && obstacleSpawnIndex < 8)
            {
                Transform spawnPoint2 = transform.GetChild(obstacleSpawnIndex).transform;
                Instantiate(obstaclePrefab2, spawnPoint2.position, Quaternion.identity, transform);
            }
        }
    }
    public GameObject coinPrefab;
    public GameObject blueSpherePrefab;
    public void SpawnCoins()
    {
        int numberofCoins = 3;
        for (int i = 0; i < numberofCoins; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandom(GetComponent<Collider>());
        }
    }
    public void SpawnSpheres()
    {
        int numberofSpheres = 2;
        for (int i = 0; i < numberofSpheres; i++)
        {
            GameObject temp = Instantiate(blueSpherePrefab, transform);
            temp.transform.position = GetRandom(GetComponent<Collider>());
        }
    }

    Vector3 GetRandom(Collider collider)
    {
        float[] x = new float[3];
        x[0] = (float)-3.3;
        x[1] = 0;
        x[2] = (float)3.3;
        int xnumber = Random.Range(1, 3);

        Vector3 point = new Vector3(
            //change x for 3 places
            x[xnumber],
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandom(collider);
        }
        point.y = 1;
        return point;
    }
}
   
