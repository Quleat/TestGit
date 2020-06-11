using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSc : MonoBehaviour
{
    public float distance;
    public float x;
    public Vector2 speed = new Vector2(1,1);
    Rigidbody2D rb;
    public float firYforce;
    public float curYForce = 1f;
    public float minYForce = 1f;
    public float xForce = 1f;
    public float interpolation = 0.5f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void activate(float distance, float x)
    {
        this.distance = distance;
        this.x = x;
        rb.velocity = new Vector2(1,0);
        Debug.Log(distance);
       StartCoroutine(onAir());
    }
    public IEnumerator onAir()
    {
        curYForce = (distance / 2) / xForce;
        minYForce = -curYForce;
        while(true){
        if(transform.position.x < x - (distance / 2))
        {
            curYForce = Mathf.Lerp(curYForce, 0,  interpolation);
            rb.velocity = new Vector2(xForce,curYForce);
        }
        else if(transform.position.x > x - (distance / 2))
        {
            curYForce *= 2; 
            rb.velocity = new Vector2(xForce, -curYForce);
        }
        else
        {
            rb.velocity = new Vector2(1, 0);
        }
        yield return new WaitForSeconds(curYForce > 0 ? curYForce : Mathf.Abs(minYForce - curYForce));
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
