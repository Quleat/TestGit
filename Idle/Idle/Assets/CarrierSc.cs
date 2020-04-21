using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierSc : MonoBehaviour
{
    Rigidbody2D _rb;
    public static Rigidbody2D rb;
    public static Transform _transform;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        rb = _rb;
        _transform = transform;
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "shop")
        {
            Score.AddGeneralPoints();
            rb.velocity = new Vector2(-1, 0);
        } else if(collision.gameObject.tag == "storage")
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    public static void Send()
    {
        rb.velocity = _transform.TransformDirection(Vector2.right);
    }
}
