using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSc : MonoBehaviour
{
    private Rigidbody2D rb;
    private float waitTime = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 1f);
    }
    void Update()
    {
        if(waitTime < 0)
        {
            Score.AddScore(200);
            Destroy(gameObject);
        }
        waitTime -= Time.deltaTime;
    }
}
