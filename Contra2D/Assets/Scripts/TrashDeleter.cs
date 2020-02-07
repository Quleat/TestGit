using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDeleter : MonoBehaviour
{
    public LayerMask WhatIsTrashCollider;
    public Transform BulletPos;
    public bool Destroing;
    public bool EnemyBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //estroing = Physics2D.OverlapCircle(new Vector2(BulletPos.position.x, BulletPos.position.y), 0, WhatIsTrashCollider);
        //if (Destroing)
        //{
            //Destroy(this.gameObject);
            //Test.hit = false;
        
        
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Turret")
        {
            Debug.Log("Hit");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
