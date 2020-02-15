using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    
    public Transform check1, check2;
    public Rigidbody2D enemy;
    private Rigidbody2D bp;
    public Transform enemyPosition;
    public SpriteRenderer enemySpriteRender;
    public LayerMask WhatIsPlayer;
    bool OnRight;
    private IEnumerator corountine;
    public bool seePlayerOnTheLeft;
    public bool seePlayerOnTheRight;
    public GameObject Bullet;
    public float othTime = 1f;
    public GameObject Character;
    public bool active = false;
    public Vector3 point_1;
    public Vector3 point_2;

    Test Test = new Test();


    void Start()
    {
        corountine = SpawnBullets(0.8f);
        StartCoroutine(corountine);
        point_1 = new Vector3(enemyPosition.position.x - 3, enemyPosition.position.y,1);
        point_2 = new Vector3(enemyPosition.position.x + 3, enemyPosition.position.y,1);
        Character = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (gameObject.transform.position.x <= point_1.x) { OnRight = true; }
            if (gameObject.transform.position.x >= point_2.x) { OnRight = false; }
            MoveEnemy();
            GameObject bullets = GameObject.FindGameObjectWithTag("Bullet");
            if (othTime <= 0 && !Test.hit)
            {

                othTime = 1;
            }
            othTime -= Time.deltaTime;
        }
        
        
    }
    IEnumerator SpawnBullets (float WaitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(WaitTime);
            SpawningBullets();
        }
    }
    void SpawningBullets()
    {     
            //seePlayerOnTheLeft = Physics2D.OverlapCircle(check1.position, 0, WhatIsPlayer);
            //seePlayerOnTheRight = Physics2D.OverlapCircle(check2.position, 0, WhatIsPlayer);
            if (Character.transform.position.x < transform.position.x && !OnRight && active)
            {
                GameObject BulletPrefab = Instantiate(Bullet) as GameObject;
                Test.hit = true;
                BulletPrefab.transform.position = enemy.position;
                bp = BulletPrefab.GetComponent<Rigidbody2D>();
                bp.velocity = new Vector2(-2f, 0);
            } else if(Character.transform.position.x > transform.position.x && OnRight)
            {
            GameObject BulletPrefab = Instantiate(Bullet) as GameObject;
            Test.hit = true;
            BulletPrefab.transform.position = enemy.position;
            bp = BulletPrefab.GetComponent<Rigidbody2D>();
            bp.velocity = new Vector2(2f, 0);
            }
    }
    void MoveEnemy()
    {
        if (OnRight)
        {
            enemy.velocity = new Vector2(1f, 0);
            enemySpriteRender.flipX = false;
        }
        if (!OnRight)
        {
            enemy.velocity = new Vector2(-1f, 0);
            enemySpriteRender.flipX = true;

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
    private void OnBecameVisible()
    {
        active = true;
    }
}
