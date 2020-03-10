using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CharacterControl : MonoBehaviour
{
    public delegate void Shoot();

    public Rigidbody2D Character;
    private Rigidbody2D bp1;
    private Rigidbody2D bp2;
    private Rigidbody2D bp3;

    private BoxCollider2D CharacterCollider;

    public GameObject Bullet;
    public GameObject menu;
    public GameObject Player;
    public GameObject[] Lives = new GameObject[3];

    public Transform player;
    public Transform Cm;
    public Transform check2;
    public Transform check;

    private IEnumerator corountine;

    public Animator CharacterAnim;

    public LayerMask WhatIsWater;
    public LayerMask WhatIsPlatform;

    public SpriteRenderer CharacterSprite;

    public Sprite LookingRight;
    public Sprite LookingRightUp;
    public Sprite LookingRightDown;
    public Sprite LookingUp;

    public float x;
    public float y;
    [SerializeField] private float bulletSpeedX = 2;
    [SerializeField] private float bulletSpeedY = 2;
    private float inv = 0f;
    public float VelocitY = 0;
    public float inputx;
    public float speed = 50f;
    public float thrust = 100f;

    public bool OnGround;
    public bool OnWater;
    public bool Jump = false;
    public bool isWater;
    public bool KeyRight;
    public bool KeyRightUp;
    public bool KeyLeft;
    public bool KeyUp;
    public bool KeyDown;
    public bool KeyJump;
    public bool KeyJumpOff;
    public bool KeyActivation;
    public bool Shooting = false;

    CheckPoint cp;
    void Start()
    {
        GameObject _CheckObject = GameObject.FindGameObjectWithTag("CheckPoint");
        Character = GetComponent<Rigidbody2D>();
        CharacterCollider = GetComponent<BoxCollider2D>();
        cp = _CheckObject.GetComponent<CheckPoint>();
        Cm = GameObject.FindGameObjectWithTag("MainCamera").transform;
        menu = GameObject.FindGameObjectWithTag("menu");
        Lives[0] = GameObject.FindGameObjectWithTag("1live");
        Lives[1] = GameObject.FindGameObjectWithTag("2live");
        Lives[2] = GameObject.FindGameObjectWithTag("3live");
        corountine = SpawnsBullets(0.3f);
    }
    void Update()
    {
        ForDebug();
        GetInput();
        Looking();
        if (KeyActivation && !Shooting) // Активация стрельбы
        {
            StartCoroutine(corountine);
            Shooting = true;
        }
        if (!KeyActivation && Shooting)
        {
            StopCoroutine(corountine);
            Shooting = false;
        }// Деактивация стрельбы
        inv -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        Moving();
    } // Апдейт для физики(перемещения персонажа в частности)
    IEnumerator SpawnsBullets(float times)
    {
        while (true)
        {
            yield return new WaitForSeconds(times);
            Shoot();
        }
    }  // Коротина для создания пуль ( Переделать, пули спавняться после каждого нажатие клавиши)
    void ShootingWithStandard()
    {
        GameObject Bulletprefab1 = Instantiate(Bullet) as GameObject;
        Bulletprefab1.transform.position = player.position;
        bp1 = Bulletprefab1.GetComponent<Rigidbody2D>();
        //if(where == "forward") { }
        bp1.velocity = new Vector2(x, y);
    } // Спавн пуль
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy" && inv <= 0)
        {          
            try
            {
                Destroy(Lives[Test.RemainLives - 1]);
                Test.RemainLives--;
                cp.Respawn();
                if (Test.PassedCheckpoint) 
                {
                    Cm.position = new Vector3(0.5f, 0.51f, -0.01f);
                }else
                {
                    Cm.position = new Vector3(-7.79f, 0.51f, -10);
                }
                Destroy(gameObject);
            }
            catch
            {
                Debug.Log("Hit");
                cp.menu.SetActive(true);
                Destroy(gameObject);
                Time.timeScale = 0;
            }
            inv = 4f;
        }
    } // Реакция на пулю
    void Looking()
    {
        if (KeyLeft)
        {
            KeyRight = true;
        }
        if(KeyUp && !KeyRight && !KeyLeft)
        {
            CharacterAnim.SetBool("Right", false);
            CharacterAnim.SetBool("RightDown", false);
            CharacterAnim.SetBool("RightUp", false);
            CharacterAnim.SetBool("Stay", false);
            CharacterAnim.SetBool("Up", true);
        }
        else if (KeyRight && KeyUp)
        {
            CharacterAnim.SetBool("Right", false);
            CharacterAnim.SetBool("RightDown", false);
            CharacterAnim.SetBool("RightUp", true);
            CharacterAnim.SetBool("Stay", false);
            CharacterAnim.SetBool("Up", false);
            x = bulletSpeedX;
            y = bulletSpeedY * 1;
        } // Стрельба вверх и вправо
        else if(KeyRight && KeyDown)
        {
            CharacterAnim.SetBool("Right", false);
            CharacterAnim.SetBool("RightDown", true);
            CharacterAnim.SetBool("RightUp", false);
            CharacterAnim.SetBool("Stay", false);
            CharacterAnim.SetBool("Up", false);
            x = bulletSpeedX;
            y = bulletSpeedY * -1;
        } // Стрельба вниз и вправо
        else if(KeyRight)
        {
            CharacterAnim.SetBool("Right", true);
            CharacterAnim.SetBool("RightDown", false);
            CharacterAnim.SetBool("RightUp", false);
            CharacterAnim.SetBool("Stay", false);
            CharacterAnim.SetBool("Up", false);
            x = bulletSpeedX;
            y = 0;
        } // Стрельба вправо
        else if(!KeyRight && !KeyDown && !KeyLeft)
        {
            CharacterAnim.SetBool("Stay", true);
            CharacterAnim.SetBool("Right", false);
            CharacterAnim.SetBool("RightDown", false);
            CharacterAnim.SetBool("RightUp", false);
            CharacterAnim.SetBool("Up", false);
            x = bulletSpeedX;
            y = 0;
        } // Анимация idle
        if (KeyLeft)
        {
            KeyRight = false;
            CharacterSprite.flipX = true;
            x *= -1;
        }//Для поворота анимации и стрельбы налево
        else if (KeyRight)
        {
            CharacterSprite.flipX = false;
            x *= 1;
        }
    } // Анимации поврота во все стороны
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
        foreach (Collider2D item in platformUp) // Нахождение платформы над игроком
        {
            BoxCollider2D bc = item.GetComponent<BoxCollider2D>();
            bc.isTrigger = true;
        }
        Collider2D[] platformDown = Physics2D.OverlapCircleAll(check.position, 0, WhatIsPlatform);
        foreach (Collider2D item in platformDown) // Нахождение платформы под игроком
        {
            BoxCollider2D bc = item.GetComponent<BoxCollider2D>();
            if (KeyJumpOff)
            {
                bc.isTrigger = true;
            }
            else
            {
                bc.isTrigger = false;
            }
        }
        if (KeyJump && OnGround && !KeyJumpOff)
        {
            Character.AddForce(new Vector2(0, 250));            
            CharacterAnim.SetBool("Jumping", true);
            Jump = true;
        }
        else if(OnGround && Jump)
        { 
            CharacterAnim.SetBool("Jumping", false);
            Jump = false;
        }
        Character.velocity = Vector3.ClampMagnitude(Character.velocity, 4.8f);
    } // Перемещения в пространстве
    void MovingOnWater()
    {
        if(OnWater)
        {
            
        }
    }
    void GetInput()
    {
        KeyRight = Input.GetKey(KeyCode.D);
        KeyLeft = Input.GetKey(KeyCode.A);
        KeyDown = Input.GetKey(KeyCode.S);
        KeyUp = Input.GetKey(KeyCode.W);
        KeyJump = Input.GetKey(KeyCode.Space);
        KeyJumpOff = Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space);
        KeyActivation = Input.GetKey(KeyCode.E);
        KeyRightUp = Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.E);
    } // Получение данных с клавиатуры
    void ForDebug()
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Time.timeScale = 0.5f;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Time.timeScale = 0.25f;
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Time.timeScale = 1f;
        }
    }    // Не влияющие на игровой процесс, только для дебага
    void ShootingSWeapon()
    {
        GameObject Bulletprefab1 = Instantiate(Bullet) as GameObject;
        Bulletprefab1.transform.position = player.position;
        bp1 = Bulletprefab1.GetComponent<Rigidbody2D>();
        bp1.velocity = new Vector2(x, y + 1);

        GameObject Bulletprefab1 = Instantiate(Bullet) as GameObject;
        Bulletprefab1.transform.position = player.position;
        bp1 = Bulletprefab1.GetComponent<Rigidbody2D>();
        bp1.velocity = new Vector2(x, y);

        GameObject Bulletprefab1 = Instantiate(Bullet) as GameObject;
        Bulletprefab1.transform.position = player.position;
        bp1 = Bulletprefab1.GetComponent<Rigidbody2D>();
        bp1.velocity = new Vector2(x, y - 1);
    }
}
