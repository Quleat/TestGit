using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxhp = 100;
    public float hp = 100;
    public float damage;
    public float speed = -1f;

    public Slider slider;

    protected Rigidbody2D rb;

    public List<GameObject> dropItems = new List<GameObject>();
    void Start()
    {
        //HealthSlider 
        GameObject slider = Instantiate<GameObject>(Resources.Load<GameObject>("HealthSlider"));
        slider.transform.SetParent(GameObject.Find("XCanvas").transform);
        slider.GetComponent<HealthSlider>().Target = this;
        rb = GetComponent<Rigidbody2D>();
        Move();
    }
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
        GameObject _drop = Instantiate(dropItems[Random.Range(0, dropItems.Capacity)], transform.position, Quaternion.Euler(0,0,0));
        Destroy(gameObject);
    }
}
