using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage;
    void OnTriggerEnter2D(Collider2D _collision)
    {
        Damage(_collision);
    }
    void Damage(Collider2D collision)
    {
        GameObject enemy = collision.gameObject;
        if(enemy.tag == "Box")
        {
            enemy.GetComponent<Box>().OpenBox();
        }
        if(enemy.tag == "Enemy")
        {
        enemy.GetComponent<Enemy>().GetDamage(damage);
        Destroy(gameObject);
        }
    }
}
