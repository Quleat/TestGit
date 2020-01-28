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
    public SpriteRenderer turretSprite;
    public Sprite TurretLeftUp;
    public Sprite TurretLeft;
    public Sprite TurretUp;
    public Sprite TurretDown;
    public Sprite TurretLeftDown;

    void Start()
    {

    }

    void Update()
    {
        posPlayerX = player.transform.position.y;
        posTurretX = player.transform.position.y - turret.transform.position.y;
        if (Mathf.Abs(Mathf.Abs(turret.transform.position.x) - Mathf.Abs(player.transform.position.x)) <= 3f && !started)
        {
            started = true;
           
            corountine = SpawnBullets(0.9f);
            StartCoroutine(corountine);


        }

        if (started)
        {
            if ((Mathf.Abs(Mathf.Abs(turret.transform.position.x) - Mathf.Abs(player.transform.position.x)) >= 3f))
            {
                StopCoroutine(corountine);
                started = false;
            }
            if (player.transform.position.x < turret.transform.position.x)
            {
                turretSprite.flipX = false;
            }
            if (player.transform.position.x > turret.transform.position.x)
            {
                turretSprite.flipX = true;
            }
            if (Mathf.Abs(player.transform.position.x - turret.transform.position.x) <= 0.1f && turret.transform.position.y - player.transform.position.y >= 0)
            {
                turretSprite.sprite = TurretDown;
            }
            else if (Mathf.Abs(player.transform.position.x - turret.transform.position.x) <= 0.1f)
            {
                turretSprite.sprite = TurretUp;
            }
            else if (Mathf.Abs(player.transform.position.y - turret.transform.position.y) <= 0.1f)
            {
                turretSprite.sprite = TurretLeft;
            }
            else if (turret.transform.position.y - player.transform.position.y >= 0)
            {
                turretSprite.sprite = TurretLeftDown;
            }
            else if (player.transform.position.y - turret.transform.position.y <= 1f)
            {
                turretSprite.sprite = TurretLeftUp;
            }
            

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
    //void OnTriggerEnter2D(Collider2D other)
    //{
        //if (other.gameObject.tag == "Player")
        //{
            //animator.SetBool("PlayerAtTheRightSide", true);
            //animator.SetBool("Triggered", true);
            //Debug.Log("hit");

        //}
        // вариант работы с системой тригеров
    //}
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
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Shooting(-1f, 0);
        }
    }

}
