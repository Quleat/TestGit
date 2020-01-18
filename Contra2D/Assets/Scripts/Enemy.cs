﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    public Transform point_1;
    public Transform point_2;
    public Transform check1, check2;
    public Rigidbody2D enemy;
    private Rigidbody2D bp;
    public Transform enemyPosition;
    public SpriteRenderer enemySpriteRender;
    public LayerMask WhatIsPlayer;
    bool OnRight;
    private IEnumerator corountine;
    public bool seePlayerOnTheLeft;
    public GameObject Bullet;
    public float othTime = 1f;
    


    void Start()
    {
        corountine = SpawnBullets(0.3f);
        StartCoroutine(corountine);
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x <= point_1.position.x) { OnRight = true; }
        if(gameObject.transform.position.x >= point_2.position.x) { OnRight = false; }
        MoveEnemy();
        GameObject bullets = GameObject.FindGameObjectWithTag("Bullet");
        if (othTime <= 0 && !Test.hit)
        {
            
            othTime = 1;
        }
        othTime -= Time.deltaTime;
        
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
            seePlayerOnTheLeft = Physics2D.OverlapCircle(check1.position, 0, WhatIsPlayer);
            if (seePlayerOnTheLeft)
            {
                GameObject BulletPrefab = Instantiate(Bullet) as GameObject;
                Test.hit = true;
                BulletPrefab.transform.position = enemy.position;
                bp = BulletPrefab.GetComponent<Rigidbody2D>();
                bp.velocity = new Vector2(-1f, 0);
            

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
}
