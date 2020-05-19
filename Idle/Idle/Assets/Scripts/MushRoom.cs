using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public int Income = 1;
    public int Lvl = 1;

    public float DigTime = 1f;
    public float Speed = 1f;
    public float boostSpeed = 1f;
    public float boostMoney = 1f;
    private float distance = 0.1f;

    LayerMask whatIsWall;
   
    Rigidbody2D rb;

    GameObject storage;

    TempStorage tempStorage;
    
    private Mushroom  mushroom;
    public Mushroom(int inc, float dig, float spe, LayerMask _whatIsWall, float _distance, Rigidbody2D _rb, TempStorage ts)
    {
        Income = inc;
        DigTime = dig;
        Speed = spe;
        whatIsWall = _whatIsWall;
        distance = _distance;
        rb = _rb;
        tempStorage = ts;
    }

    public int Dig()
    {
        return (int)(Income * boostSpeed);
    }
    private void Rotate()
    {
        transform.Rotate(new Vector3(0, 180, 0), Space.Self);
        rb.velocity = transform.TransformDirection(Vector2.right * Speed);
    }
     public void Mine()
    {
       
    }
    public IEnumerator active()
    {
        while (true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), distance, whatIsWall);
            if (hit)
            {
                if (hit.collider.gameObject == storage)
                {
                    tempStorage.AddPoints();
                    Speed = tempStorage.speed;
                    Income = tempStorage.income;
                    Rotate();
                    yield return null;
                }
                else
                {
                    rb.velocity = new Vector2(0, 0);
                    yield return new WaitForSeconds(DigTime);
                    Rotate();
                }
            }
            else
            {
                rb.velocity = transform.TransformDirection(Vector2.right * Speed);
            }
            yield return null;
        }
    }
}
