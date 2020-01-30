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
    public Sprite TurretRightDown;
    public Sprite TurretRight;
    public Sprite TurretRightUp;
    public float x = -1f;
    public float y = 0;
    public float oth1 = 1;
    public float oth2 = 1;
        
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
            }//включается при появлении игрока

            if (Mathf.Abs(player.transform.position.x - turret.transform.position.x) <= 0.2f && turret.transform.position.y > player.transform.position.y)
            {
                turretSprite.sprite = TurretDown;
            } // турель вниз
            else if (Mathf.Abs(player.transform.position.x - turret.transform.position.x) <= 0.1f)
            {
                turretSprite.sprite = TurretUp;
                x = 0;
                y = 1;
            }// турель вверх
            else if (Mathf.Abs(player.transform.position.y - turret.transform.position.y) <= 0.1f && player.transform.position.x < turret.transform.position.x)
            {
                turretSprite.sprite = TurretLeft;
                x = -1;
                y = 0;
            }//турель налево
            else if (player.transform.position.y >= -0.2f && player.transform.position.y <= 0.2f && player.transform.position.x > turret.transform.position.x)
            {
                Debug.Log("df");
                turretSprite.sprite = TurretRight;

            }// турель направо
            else if (turret.transform.position.y > player.transform.position.y && player.transform.position.x < turret.transform.position.x)
            {
                turretSprite.sprite = TurretLeftDown;
                x = -1;
                y = -1;
            }// турель налево и вниз
            else if (turret.transform.position.y > player.transform.position.y && player.transform.position.x > turret.transform.position.x)
            {
                turretSprite.sprite = TurretRightDown;
                x = -1;
                y = -1;
            }
            else if (player.transform.position.y - turret.transform.position.y <= 1f && player.transform.position.x < turret.transform.position.x)
            {
                turretSprite.sprite = TurretLeftUp;
                x = -1;
                y = 1;

            }// турель налево и вверх
            else if (player.transform.position.y - turret.transform.position.y <= 1f && player.transform.position.x > turret.transform.position.x)
            {
                turretSprite.sprite = TurretRightUp;
            }// турель направо и вверх
            
            if (player.transform.position.x < turret.transform.position.x)
            {
               
                oth1 = 1;
                oth2 = 1;
                
            }
            if (player.transform.position.x > turret.transform.position.x + 0.5)
            {
             
                oth1 = -1;
                if (turretSprite.sprite == TurretLeftUp && turretSprite.sprite == TurretRightUp && turretSprite.sprite == TurretLeftDown) { oth2 = 1; }
                else { oth2 = -1; }
            }
            x *= oth1;
            y *= oth2;
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
    private void Shooting()
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
            Shooting();
        }
    }

}
