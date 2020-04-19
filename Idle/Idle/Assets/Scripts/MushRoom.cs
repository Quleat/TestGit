using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : MonoBehaviour
{
    public int minerType;
    public float digTime = 1f;
    Rigidbody2D rb;
    public LayerMask WhatIsWall;
    public bool dig = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.1f, WhatIsWall);
        if (hit && !dig)
        {
            if (hit.collider.gameObject.tag == "1st")
            {
                Score.AddPoints(minerType);
                transform.Rotate(new Vector3(0, 180, 0), Space.Self);
            }
            else
            {
                StartCoroutine(Diging());
            }
        }
        else
        {
            rb.velocity = transform.TransformDirection(Vector2.right * gameData.minerSpeed[minerType]);
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right));
    }
    IEnumerator Diging()
    {
        dig = true;
        rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(digTime);
        transform.Rotate(new Vector3(0, 180, 0), Space.Self);
        dig = false;
    }
}
