using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom
{
    public int Income = 1;
    public int Lvl = 1;
    public int cost = 0;
    public int Cost
    {
        get
        {
            return cost;
        }
        set
        {
            cost *= value;
        }
    }

    public float DigTime = 1f;
    public float Speed = 0.2f;
    public float boostSpeed = 1f;
    public float boostMoney = 1f;
    private float distance;
    private float curTime = 0;

    Transform transform;

    LayerMask whatIsWall;
   
    Rigidbody2D rb;

    private bool digging;

    private GameObject storage;

    private TempStorage tempStorage;
    public MushRoom(int inc, float dig, float spe, Transform _transform, LayerMask _whatIsWall, float _distance, Rigidbody2D _rb, GameObject _storage)
    {
        Income = inc;
        DigTime = dig;
        Speed = spe;
        transform = _transform;
        whatIsWall = _whatIsWall;
        distance = _distance;
        rb = _rb;
        storage = _storage;
        tempStorage = storage.GetComponent<TempStorage>();
    }

    public int Dig()
    {
        return (int)(Income * boostSpeed);
    }
    public void Upgrade(ref int income, ref float speed)
    {
        income *= 2;
        speed *= 2f;
        Cost = 2;
        Debug.Log(Cost);
    }
    private void Rotate()
    {
        transform.Rotate(new Vector3(0, 180, 0), Space.Self);
        rb.velocity = transform.TransformDirection(Vector2.right * Speed * Time.deltaTime);
    }
    public void Mine(float speed, float digTime)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), distance, whatIsWall);
        if (hit)
        {
            if (hit.collider.gameObject == storage)
            {
                tempStorage.AddPoints();
                Rotate();
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
                if (curTime >= digTime)
                {
                    digging = false;
                    Rotate();
                }
            }
        }
        else
        {
            rb.velocity = transform.TransformDirection(Vector2.right * speed * Time.deltaTime);
        }
    }
}
