using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    private IEnumerator corountine;
    public float WaitTime = 5f;
    public float Waiting = 5f;
    private bool started = false;

    void Start()
    {
        corountine = SpawnsEnemy(WaitTime);
        StartCoroutine(corountine);
    }

    void Update()
    {
        if(!started)
        {
            if(Waiting <= 0)
            {
                corountine = SpawnsEnemy(WaitTime);
                StartCoroutine(corountine);
                Waiting = 5f;
            }
            Waiting -= Time.deltaTime;
        }
        
    }
    IEnumerator SpawnsEnemy(float times)
    {
        started = true;
        SpawnEnemy();
        yield return new WaitForSeconds(times);
        
    }
    void SpawnEnemy()
    {
        GameObject NewEnemy = Instantiate(Enemy) as GameObject;
        Rigidbody2D rb = NewEnemy.GetComponent<Rigidbody2D>();
        rb.MovePosition(transform.position);
        Debug.Log("SpawnedEnemySuccefuly");
        StopCoroutine(corountine);
        started = false;
    }
}
