using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public GameObject Bullet;
    public Transform turret;
    public float WaitTime;

    void Start()
    {
     
    }

    void Update()
    {
        
    }
    private void OnBecameVisible()
    {
        this.gameObject.SetActive(true);
    }
    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            animator.SetBool("PlayerAtTheRightSide", true);
            animator.SetBool("Triggered", true);
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        Shooting(-1f, 0);
    }
    private void Shooting(float x, float y)
    {
        if (WaitTime <= 0)
        {
            GameObject BulletPrefab = Instantiate(Bullet) as GameObject;
            Rigidbody2D rb = BulletPrefab.GetComponent<Rigidbody2D>();
            rb.MovePosition(turret.position);
            rb.velocity = new Vector2(x, y);
            WaitTime = 15f;
        }
        WaitTime -= Time.deltaTime;
    }
    

}
