using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class collector: MonoBehaviour
{
    Rigidbody2D rb;
    public LayerMask WhatIsPlatform;
    public LayerMask WhatIsStorage;
    public LayerMask WhatIsTempStorage;
    public LayerMask WhatIsCollectorEnd;
    public float waitTime = 15f;
    private int caring = 0;
    public bool activated = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Collecting());
    }
    void Update()
    {

    }
    IEnumerator Collecting()
    {
        while (true)
        {
            Debug.DrawLine(transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
            rb.velocity = new Vector2(0, Score.collectorSpeed);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 10f);
            if (hit.collider.gameObject.layer == 11)
            {
                Debug.DrawLine(transform.position, hit.transform.position);
                int minerType = hit.collider.GetComponent<TempStorage>().minerType;
                rb.velocity = new Vector2(0, 0);
                yield return new WaitForSeconds(1f);
                caring += Score.tempStorage[minerType];
                Score.ClearStorage(minerType);
                rb.velocity = new Vector2(0, Score.collectorSpeed);
                yield return new WaitForSeconds(0.5f);
            }
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.up, 100);
            if (hit2 == false)
            {
                rb.velocity = new Vector2(0, 0);
                StartCoroutine(Folding());
                yield break;
            }
            yield return new WaitForSeconds(0.1f);
          
        }
    }
    IEnumerator Folding()
    {
        while (true)
        {
            Debug.Log("Folding");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
            rb.velocity = new Vector2(0, -Score.collectorSpeed);
            if (hit != false)
            {
                if (hit.collider.gameObject.layer == 12)
                {
                    Debug.Log("EndFolding");
                    rb.velocity = new Vector2(0, 0);
                    yield return new WaitForSeconds(1f);
                    Score.AddCollectorPoints(caring);
                    caring = 0;
                    StartCoroutine(Collecting());
                    yield break;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    void StartingCoroutins()
    {
        
    }
}
