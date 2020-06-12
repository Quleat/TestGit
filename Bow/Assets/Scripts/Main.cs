using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
   public List<GameObject> enemiesPrefabs = new List<GameObject>();
   public List<Transform> spawnPoints = new List<Transform>();
   public float spawnTime = 10f;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(9,9);
        Physics2D.IgnoreLayerCollision(9,10);
        StartCoroutine(SpawningEnemies());
    }
    IEnumerator SpawningEnemies()
    {
        while(true)
        {
        GameObject enemy = Instantiate(enemiesPrefabs[Random.Range(0,enemiesPrefabs.Capacity)], spawnPoints[Random.Range(0, spawnPoints.Capacity)].position, Quaternion.Euler(0,0,0));
        yield return new WaitForSeconds(spawnTime);
        }
    }
}
