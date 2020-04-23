using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierSc : MonoBehaviour
{
    Rigidbody2D _rb;
    public Transform _transform;
    int carriing = 0;
    public bool atBase;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _transform = transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "shop")
        {
            Score.AddGeneralPoints(carriing);
            _rb.velocity = new Vector2(-1, 0);
        } else if(collision.gameObject.tag == "storage")
        {
            _rb.velocity = new Vector2(0, 0);
            atBase = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "storage")
        {
            atBase = false;
        }
    }
    public void Send()
    {
        if (atBase)
        {
            carriing = 0;
            _rb.velocity = _transform.TransformDirection(Vector2.right);
            carriing += gameData.points;
            gameData.points = 0;
            Score.UpdateMoney();
        }
    }
}
