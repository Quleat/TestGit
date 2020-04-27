using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom
{
    public int Income = 1;
    public float DigTime = 1f;
    public float Speed = 0.2f;
    public float boostSpeed = 1f;
    public float boostMoney = 1f;
    public int Lvl = 1;
    Transform transform;
    LayerMask whatIsWall;
    float distance;
    Rigidbody2D rb;
    Vector3 direction;

    private float curTime = 0;
    private bool digging;
    public int Cost
    {
        get
        {
            return Cost;
        }
        set
        {
            Cost *= value; 
        }
    }
    public MushRoom(int inc, float dig, float spe, Transform _transform, LayerMask _whatIsWall, float _distance, Rigidbody2D _rb, Vector3 _direction)
    {
        Income = inc;
        DigTime = dig;
        Speed = spe;
        transform = _transform;
        whatIsWall = _whatIsWall;
        distance = _distance;
        rb = _rb;
        direction = _direction;
    }

    public int Dig()
    {
        return (int)(Income * boostSpeed);
    }
    public void Upgrade()
    {
        Income = (int)(Income * 1.5);
        Speed = (int)(Speed * 1.5);
        Cost = 2;
        Debug.Log(Cost);
    }
    private void Rotate()
    {
        transform.Rotate(new Vector3(0, 180, 0), Space.Self);
        rb.velocity = transform.TransformDirection(Vector2.right * Speed * Time.deltaTime);
    }
    public bool Mine()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), distance, whatIsWall);
        if (hit)
        {
            if (hit.collider.gameObject.tag == "1st")
            {
                Rotate();
                return true;
            }
            else
            {
                if (!digging)
                {
                    rb.velocity = new Vector2(0, 0);
                    digging = true;
                    curTime = 0;
                }
                curTime += Time.deltaTime;
                if(curTime >= DigTime)
                {
                    digging = false;
                    Rotate();
                }
            }
        }
        else
        {
            rb.velocity = transform.TransformDirection(Vector2.right * Speed * Time.deltaTime);
        }
        return false;
    }
}
