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
        player = (GameObject.FindGameObjectWithTag("Player").transform);
    }

    void Update()
    {
        Shooting();
        WaitTime -= Time.deltaTime;
        Looking();
    }
    private void Shooting()
    {
        if (WaitTime <= 0)
        {
            GameObject BulletPrefab = Instantiate(Bullet) as GameObject;
            Rigidbody2D rb = BulletPrefab.GetComponent<Rigidbody2D>();
            rb.MovePosition(new Vector3(turret.position.x, turret.position.y, 0f));
            rb.velocity = new Vector2(x, y);
            WaitTime = 2f;
        }

    }
    private void Looking()
    {
        try
        {
            if (Mathf.Abs(player.transform.position.x - turret.transform.position.x) <= 0.2f && turret.transform.position.y > player.transform.position.y)
            {
                turretSprite.sprite = TurretDown;
                x = 0;
                y = -1;
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
                turretSprite.sprite = TurretRight;
                x = 1;
                y = 0;

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
                x = 1;
                y = -1;
            }// направо и вниз
            else if (player.transform.position.y - turret.transform.position.y <= 1f && player.transform.position.x < turret.transform.position.x)
            {
                turretSprite.sprite = TurretLeftUp;
                x = -1;
                y = 1;

            }// турель налево и вверх
            else if (player.transform.position.y - turret.transform.position.y <= 1f && player.transform.position.x > turret.transform.position.x)
            {
                turretSprite.sprite = TurretRightUp;
                x = 1;
                y = 1;
            }
        }
        catch
        {
            try
            {
                player = (GameObject.FindGameObjectWithTag("Player").transform);
                Debug.Log("Переопределине игрока");
            }
            catch
            {
                Debug.Log("Игрок Уничтожен");
            }
        }
    }
}
