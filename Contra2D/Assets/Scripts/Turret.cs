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
    private IEnumerator corountine;
    private bool started = false;
    public float posPlayerX;
    public float posTurretX;

    void Start()
    {
        
    }

    void Update()
    {
        posPlayerX = player.transform.position.x;
        posTurretX = Mathf.Abs(Mathf.Abs(turret.transform.position.x) - Mathf.Abs(player.transform.position.x));
        if (Mathf.Abs(Mathf.Abs(turret.transform.position.x) - Mathf.Abs(player.transform.position.x)) <= 3f && !started)
        {
            Debug.Log("+++");
            started = true;
            corountine = SpawnBullets(0.9f);
            StartCoroutine(corountine);
            
            
        }

        if (started)
        {
            if ((Mathf.Abs(Mathf.Abs(turret.transform.position.x) - Mathf.Abs(player.transform.position.x)) >= 3f))
            {
                Debug.Log("end");
                StopCoroutine(corountine);
            started = false;
            }
                

        }
        if(player.transform.position.x < turret.transform.position.x)
        {
            //SpriteRenderer.flipX
        }
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
            //animator.SetBool("PlayerAtTheRightSide", true);
            //animator.SetBool("Triggered", true);
            //Debug.Log("hit");
            
        }
    }
    //void OnTriggerExit2D(Collider2D other)
    //{
        //StopCoroutine(corountine);
    //}
    private void Shooting(float x, float y)
    {
        
            GameObject BulletPrefab = Instantiate(Bullet) as GameObject;
            Rigidbody2D rb = BulletPrefab.GetComponent<Rigidbody2D>();
            rb.MovePosition(new Vector3(turret.position.x, turret.position.y, 0f));
            rb.velocity = new Vector2(x, y);
            
        
    }
    IEnumerator SpawnBullets(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            Shooting(-1f, 0);
        }
    }

}
