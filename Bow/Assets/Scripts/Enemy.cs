using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float hp = 1;
    public float damage;
    public float speed = -1f;

    public Slider slider;

    protected Rigidbody2D rb;

    public List<GameObject> dropItems = new List<GameObject>();
    public void GetDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Die();
        }
    }
    protected virtual void Move()
    {
        rb.velocity = new Vector2(speed, 0);
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        Wall.GetDamage(damage);
        Die();
    }
    void Die()
    {

    }
}
