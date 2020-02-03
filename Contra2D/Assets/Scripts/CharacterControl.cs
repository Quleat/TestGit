using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CharacterControl : MonoBehaviour
{
    public Rigidbody2D Character;
    private Rigidbody2D bp1;
    private Rigidbody2D bp2;
    private Rigidbody2D bp3;
    public float inputx;
    public float speed = 50f;
    public float thrust = 100f;
    public GameObject Bullet;
    public Transform player;
    public Transform Cm;
    private IEnumerator corountine;
    public GameObject menu;
    public Animator CharacterAnim;
    public LayerMask WhatIsWater;
    public LayerMask WhatIsPlatform;
    public bool isWater;
    public Transform check;
    public bool OnGround;
    public Transform check2;
    public float VelocityX = 0;

    void Start()
    {
        Character = GetComponent<Rigidbody2D>();
    }
   void Update()
    {
        VelocityX = Character.velocity.x;
        inputx = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(inputx, Character.velocity.y) * Time.deltaTime * speed;
        Character.velocity = movement;
        if (Input.GetKeyDown(KeyCode.W) && OnGround)
        {
            Character.AddForce(new Vector2(0, 600));
            CharacterAnim.SetBool("Jumping", true);
        }
        isWater = Physics2D.OverlapCircle(check.position, 0, WhatIsWater);
        OnGround = Physics2D.OverlapCircle(check.position, 0, WhatIsPlatform);
        Collider2D[] platformUp = Physics2D.OverlapCircleAll(check2.position, 0, WhatIsPlatform);
        foreach (Collider2D item in platformUp)
        {
            BoxCollider2D bc = item.GetComponent<BoxCollider2D>();
            bc.isTrigger = true;
        }
        Collider2D[] platformDown = Physics2D.OverlapCircleAll(check.position, 0, WhatIsPlatform);
        foreach (Collider2D item in platformDown)
        {
            BoxCollider2D bc = item.GetComponent<BoxCollider2D>();
            if (Input.GetKey(KeyCode.S))
            {
                bc.isTrigger = true;
            }
            else
            {
                bc.isTrigger = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            corountine = SpawnsBullets(0.3f);
            StartCoroutine(corountine);            
        }
        if (Input.GetKeyUp(KeyCode.F)) { StopCoroutine(corountine); }
        if ((player.position.x) >= -7.7 && player.position.x > Cm.position.x) { Cm.transform.position = new Vector3(player.position.x, Cm.transform.position.y, -1); }
        if(OnGround)
        {
            CharacterAnim.SetBool("Jumping", false);
        }

        
    }
    private void FixedUpdate()
    {
        
    }
    IEnumerator SpawnsBullets(float times)
    {
     while(true)
        {
            yield return new WaitForSeconds(times);
            SpawnBullet();
        }
    }
    void SpawnBullet()
    { 
        GameObject Bulletprefab1 = Instantiate(Bullet) as GameObject;
        Bulletprefab1.transform.position = player.position;
        bp1 = Bulletprefab1.GetComponent<Rigidbody2D>();
        //if(where == "forward") { }
        bp1.velocity = new Vector2(1f, 1f);
        

        GameObject Bulletprefab2 = Instantiate(Bullet) as GameObject;
        Bulletprefab2.transform.position = player.position;
        bp2 = Bulletprefab2.GetComponent<Rigidbody2D>();
        //if(where == "forward") { }
        bp2.velocity = new Vector2(1f, 0);

        GameObject Bulletprefab3 = Instantiate(Bullet) as GameObject;
        Bulletprefab3.transform.position = player.position;
        bp3 = Bulletprefab3.GetComponent<Rigidbody2D>();
        //if(where == "forward") { }
        bp3.velocity = new Vector2(1f, -1f);
    }
   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy")
        {
            Debug.Log("Hit");
            menu.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
            
        }
    }
}
