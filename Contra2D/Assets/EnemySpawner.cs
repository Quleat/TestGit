using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    private IEnumerator corountine;
    public float WaitTime = 15f;

    void Start()
    {
        corountine = SpawnsEnemy(WaitTime);
        StartCoroutine(corountine);
    }

    void Update()
    {
        
    }
    IEnumerator SpawnsEnemy(float times)
    {
        yield return new WaitForSeconds(times);
        SpawnEnemy();
    }
    void SpawnEnemy()
    {
        GameObject NewEnemy = Instantiate(Enemy) as GameObject;
        Rigidbody2D rb = NewEnemy.GetComponent<Rigidbody2D>();
        rb.MovePosition(transform.position);

        Debug.Log("SpawnedEnemySuccefuly");
    }
}
