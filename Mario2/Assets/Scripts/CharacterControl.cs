using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float inputx;
    public float speed = 50f;
    public float jumpForce = 5f;
    public Vector3 movement;

    public bool onGround;
    public bool onAir;

    private bool leftButton;
    private bool rightButton;
    private bool jumpButton;
    private bool downButton;

    public Transform checkGround;
    public Transform checkAir;

    public LayerMask _whatIsGround;
    public LayerMask _whatIsBrick;

    public Text _pointCount;
    public float pointCount;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        GetInput();
        Move();
        Jump();
    }
    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        movement = new Vector2(inputX, rb.velocity.y) * speed;
        rb.velocity = movement;
    }
    private void Jump()
    {
        onGround = Physics2D.OverlapCircle(new Vector2(checkGround.position.x, checkGround.position.y), 0, _whatIsGround);
        onAir = Physics2D.OverlapCircle(new Vector2(checkAir.position.x, checkAir.position.y), 0, _whatIsBrick);
        if(onAir)
        {
            GameObject _gameObjUp = Physics2D.OverlapCircle(new Vector2(checkGround.position.x, checkGround.position.y), 0, _whatIsGround).gameObject;
            _gameObjUp.GetComponent<RandomBrick>().activation();
        }
        if (onGround && jumpButton)
        {
            rb.AddForce(new Vector2(0, 1f), ForceMode2D.Impulse);
        }
    }
    private void GetInput()
    {
        jumpButton = Input.GetKey(KeyCode.Space);
    }
}
