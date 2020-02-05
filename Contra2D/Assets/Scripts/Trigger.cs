using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool OnTrigger = false;
    private IEnumerator corountine;
    public GameObject Enemy;
   // public Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        corountine = SpawnEnemy();
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            OnTrigger = true;
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            OnTrigger = false;
        }
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            
                yield return new WaitForSeconds(1f);
                SpawnEnemies();
            
            //StartCoroutine(SpawnEnemy());
        }
    }
    private void SpawnEnemies()
    {
        if (OnTrigger)
        {
            GameObject EnemyPrefab = Instantiate(Enemy) as GameObject;
            EnemyPrefab.transform.position = new Vector3(-5f, 1f, 0);
            Debug.Log("Working");
        }
    }
}
