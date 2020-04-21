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
    public bool activated = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //private void Awake()
    //{
    //    StartCoroutine(Collecting());
    //}
    void Update()
    {
        if (waitTime <= 0 && !activated)
        {
            activated = true;
            StartCoroutine(Collecting());
        }
        waitTime -= Time.deltaTime;
        //if (!returning)
        //{
            
        //    else
        //    {
        //        StopCoroutine(Collecting());
        //        returning = true;
        //    }
        //}
        //else
        //{
        //    StartCoroutine(Folding());
        //}
    }
    IEnumerator Collecting()
    {
        Debug.Log("activated1");
        //StopCoroutine(Folding());
        while (true)
        {
            Debug.Log("activated2");
            Debug.DrawLine(transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
            rb.velocity = new Vector2(0, 1);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 10f);
            if (hit.collider.gameObject.layer == WhatIsTempStorage)
            {
                Debug.DrawLine(transform.position, hit.transform.position);
                int minerType = hit.collider.GetComponent<TempStorage>().minerType;
                rb.velocity = new Vector2(0, 0);
                yield return new WaitForSeconds(1f);
                rb.velocity = new Vector2(0, 1);
                yield return new WaitForSeconds(1f);
                gameData.points += Score.tempStorage[minerType];
                Score.tempStorage[minerType] = 0;
            }
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.up, 100);
            if (hit2.collider.gameObject.layer == WhatIsCollectorEnd)
            {
                Debug.Log("EndCollecting");
                yield return new WaitForSeconds(2f);
                StartCoroutine(Folding());
                yield break;
                //StopCoroutine(Collecting());
            }
            //yield return new WaitForSeconds(0);
        }
       
    }
    IEnumerator Folding()
    {
        activated = true;
        while (true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
            if (hit.collider.gameObject.layer == WhatIsStorage)
            {
                activated = true;
                Debug.Log("EndFolding");
                yield return new WaitForSeconds(1f);
                StartCoroutine(Collecting());
                yield break;
            }
        }
    }
    void StartingCoroutins()
    {
        
    }
}
