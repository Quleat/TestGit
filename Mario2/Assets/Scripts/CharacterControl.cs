using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody2D rb;

    private float inputx;
    private float speed = 1f;
    private float jumpForce = 5f;
    private Vector3 movement;

    public bool onGround;
    public bool onAir;

    private bool jumpButton;

    public Transform checkGround;
    public Transform checkAir;

    public LayerMask _whatIsGround;
    public LayerMask _whatIsBrick;

    private Transform cm;

    public GameObject _bigPlayerPrefab;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cm = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    void FixedUpdate()
    {
        GetInput();
        Move();
        CheckAndJump();
    }
    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal"); // Перемещения песонажа по оси Х
        movement = new Vector2(inputX, rb.velocity.y) * speed;
        rb.velocity = movement;

        if(rb.velocity.x > 0 && transform.position.x > cm.position.x)   // Пермещения камеры
        {
           cm.position = new Vector3(transform.position.x, cm.position.y, transform.position.z - 10); 
        }
    }
    private void CheckAndJump()
    {
        onGround = Physics2D.OverlapCircle(new Vector2(checkGround.position.x, checkGround.position.y), 0, _whatIsGround);
        onAir = Physics2D.OverlapCircle(new Vector2(checkAir.position.x, checkAir.position.y), 0, _whatIsBrick);
        if(onAir && rb.velocity.y > 0)
        {
            GameObject _gameObjUp = Physics2D.OverlapCircle(new Vector2(checkAir.position.x, checkAir.position.y), 0, _whatIsBrick).gameObject;
            _gameObjUp.GetComponent<BrickSc>().activation();
        }
        if (onGround && jumpButton)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void GetInput()
    {
        jumpButton = Input.GetKey(KeyCode.Space);
    }
    public void ChangeSize()
    {
        GameObject _newPlayer = Instantiate(_bigPlayerPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0,0,0,0)) as GameObject;
        Destroy(gameObject);
    }
}
