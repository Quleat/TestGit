using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashDeleterEnemy : MonoBehaviour
{
    public LayerMask WhatIsTrashCollider;
    public Transform BulletPos;
    public bool Destroing;
    public Canvas menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Destroing = Physics2D.OverlapCircle(new Vector2(BulletPos.position.x, BulletPos.position.y), 0, WhatIsTrashCollider);
       // if (Destroing)
        //{
           // Destroy(this.gameObject);
          //  Test.hit = false;
       // }
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
    
    }


