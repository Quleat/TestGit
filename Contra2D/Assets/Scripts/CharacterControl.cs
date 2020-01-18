using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CharacterControl : MonoBehaviour
{
    public Rigidbody2D Character;
    public Rigidbody2D bp;
    public float inputx;
    public float speed = 50f;
    public float thrust = 100f;
    Check check;
    public GameObject Bullet;
    public Transform player;
    public Transform Cm;
    private IEnumerator corountine;
    void Start()
    {
        Character = GetComponent<Rigidbody2D>();
        check = FindObjectOfType<Check>();
    }
   void Update()
    {
        inputx = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(inputx, Character.velocity.y) * Time.deltaTime * speed;
        Character.velocity = movement;
        if (Input.GetKeyDown(KeyCode.W) && check.OnGround) Character.AddForce(new Vector2(0,600));
        if(Input.GetKeyDown(KeyCode.F))
        {
            corountine = SpawnsBullets(0.3f);
            StartCoroutine(corountine);            
        }
        if (Input.GetKeyUp(KeyCode.F)) { StopCoroutine(corountine); }
        if ((player.position.x) >= -7.7) { Cm.transform.position = new Vector3(player.position.x, Cm.transform.position.y, -1); }
        
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
        GameObject Bulletprefab = Instantiate(Bullet) as GameObject;
        Bulletprefab.transform.position = player.position;
        bp = Bulletprefab.GetComponent<Rigidbody2D>();
        bp.velocity = new Vector2(1f, 0);
    }
   void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
