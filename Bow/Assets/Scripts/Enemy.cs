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

    protected Rigidbody2D rb;

    public List<GameObject> dropItems = new List<GameObject>();

    GameObject slider;
    Slider _slider;
    GameObject damageIndication;
    Text _damageIndication;
    void Start()
    {
        //HealthSlider 
        AdjustDifficulity();
        slider = Instantiate<GameObject>(Resources.Load<GameObject>("HealthSlider"));
        slider.transform.SetParent(GameObject.Find("Canvas").transform);
        slider.GetComponent<HealthSlider>().Target = this;
        _slider = slider.GetComponent<Slider>();
        _slider.maxValue = hp;
        _slider.value =  hp; 
        rb = GetComponent<Rigidbody2D>();
        Move();
    }
    public void GetDamage(float damage)
    {
        IndicateDamage(damage);
        hp -= damage;
        _slider.value =  hp;
        if(hp <= 0)
        {
            Die();
        }
    }
    void IndicateDamage(float damage)
    {
    damageIndication = Instantiate<GameObject>(Resources.Load<GameObject>("DamageIndication")); // Надо закешировать
    damageIndication.transform.SetParent(GameObject.Find("Canvas").transform);
    damageIndication.GetComponent<Text>().text = damage.ToString();
    damageIndication.GetComponent<DamageIndicator>().Target = this;
    Destroy(damageIndication, 2f);
    }
    void AdjustDifficulity()
    {
        hp *= Main.level;
        damage *= Main.level;
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
        GameObject _drop = Instantiate(dropItems[Random.Range(0, dropItems.Capacity - 1)], transform.position, Quaternion.Euler(0,0,0));
        Destroy(damageIndication);
        Destroy(slider);
        Destroy(gameObject);
    }
}
