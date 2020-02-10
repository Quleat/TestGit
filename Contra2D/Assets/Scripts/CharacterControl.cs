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
    public SpriteRenderer CharacterSprite;
    public Sprite LookingRight;
    public Sprite LookingRightUp;
    public Sprite LookingRightDown;
    public Sprite LookingUp;
    private float x;
    private float y;
    bool RunningAnim = false;

    public GameObject[] Lives = new GameObject[3];

    void Start()
    {
        Character = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        VelocityX = Character.velocity.x;
        if (Input.GetKeyDown(KeyCode.F))
        {
            corountine = SpawnsBullets(0.3f);
            StartCoroutine(corountine);
        }
        if (Input.GetKeyUp(KeyCode.F)) { StopCoroutine(corountine); }
        Moving();
        Looking();


    }
    IEnumerator SpawnsBullets(float times)
    {
        while (true)
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
            if(Test.RemainLives >= 0)
            {
                Destroy(Lives[Test.RemainLives]);
                Test.RemainLives--;
                Test.Respawn();
            } else
            {
                Debug.Log("Hit");
                menu.SetActive(true);
                Destroy(gameObject);
                Time.timeScale = 0;               
            }        
        }
    }
    void Looking()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RunningAnim = true;
            if (Input.GetKey(KeyCode.Keypad9))
            {
                CharacterAnim.SetBool("LookingRightUpRunning", true);
            }
        }
        else
        {
            RunningAnim = false;
            CharacterAnim.SetBool("LookingRightUpRunning", false);
        }
        
        if (!RunningAnim)
        {
            if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.S))
            {
                CharacterSprite.sprite = LookingRightDown;
                CharacterSprite.flipX = false;
                x = 1;
                y = -1;
                corountine = SpawnsBullets(0.3f);
                StartCoroutine(corountine);
            } //направо и вниз
            else if (Input.GetKeyDown(KeyCode.D))
            {
                CharacterSprite.sprite = LookingRight;
                CharacterSprite.flipX = false;
                x = 1;
                y = 0;
            } // направо
            else if (Input.GetKey(KeyCode.Keypad9))
            {
                //CharacterSprite.sprite = LookingRightUp;
                CharacterSprite.flipX = false;
                x = 1;
                y = 1;
                CharacterAnim.SetBool("LookingRightUp", true);
            }
            // направо и вверх
            else if (Input.GetKeyDown(KeyCode.A))
            {
                CharacterSprite.sprite = LookingRight;
                CharacterSprite.flipX = true;
                x = -1;
                y = 0;
            } // налево
            else if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.W))
            {
                CharacterSprite.sprite = LookingRightUp;
                CharacterSprite.flipX = true;
                x = -1;
                y = 1;
            } // налево и вверх
            else if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S))
            {
                CharacterSprite.sprite = LookingRightDown;
                CharacterSprite.flipX = true;
                x = -1;
                y = -1;
            } // налево и вниз
            
            
        }
        else
        {
            //Debug.Log("StopAnimation");
            CharacterAnim.SetBool("LookingRightUpRunning", false);
            CharacterAnim.SetBool("LookingRightUp", false);
        }
    }
    void Moving()
    {
        if (Input.GetKey(KeyCode.C)) 
        {
            inputx = 0;
        } 
        else
        {
            inputx = Input.GetAxis("Horizontal");
        }
        Vector2 movement = new Vector2(inputx, Character.velocity.y) * Time.deltaTime * speed;
        
        Character.velocity = movement;
        if ((player.position.x) >= -7.7 && player.position.x > Cm.position.x) { Cm.transform.position = new Vector3(player.position.x, Cm.transform.position.y, -1); }
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
            if (Input.GetKeyDown(KeyCode.S))
            {
                bc.isTrigger = true;
            }
            else
            {
                bc.isTrigger = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            Character.AddForce(new Vector2(0, 600));
            CharacterAnim.SetBool("Jumping", true);
        }
        if (OnGround)
        {
            CharacterAnim.SetBool("Jumping", false);
        }
    }
}
