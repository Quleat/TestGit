using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murshroom : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public bool exitBrick;
    public int moveCof;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveCof, 1 - moveCof);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            moveCof = 1;
            bc.isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterControl>().ChangeSize();
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
