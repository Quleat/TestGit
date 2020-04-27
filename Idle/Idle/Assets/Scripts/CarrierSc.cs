using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierSc : MonoBehaviour
{
    Rigidbody2D _rb;
    public Transform _transform;
    int carrying = 0;
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
            gameData.GeneralPoints += carrying;
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
            carrying = 0;
            _rb.velocity = _transform.TransformDirection(Vector2.right);
            carrying += gameData.LocalPoints;
            gameData.LocalPoints = 0;
        }
    }
}
