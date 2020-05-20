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
    private int carrying = 10;
    public bool activated = false;
    public  static float Speed = 0.5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Collecting());
    }
    IEnumerator Collecting()
    {
        yield return new WaitForSeconds(0.1f);
        int storCount = gameData.tempStorages.Count;
        Queue<GameObject> curTempStorage = new Queue<GameObject>();
        foreach(GameObject g in gameData.tempStorages)
        {
            curTempStorage.Enqueue(g);
        }
        while (true)
        {
            
            rb.velocity = new Vector2(0, Speed);
            if (transform.position.y >= curTempStorage.Peek().transform.position.y)
            {
                
                rb.velocity = new Vector2(0, 0);
                int minerType = storCount - curTempStorage.Count;
                yield return new WaitForSeconds(1f);
                carrying += gameData.TempStoragePoints[minerType];
                gameData.ClearTempPoints(minerType);
                rb.velocity = new Vector2(0, Speed);
                
                curTempStorage.Dequeue();
                if(gameData.tempStorages.Count > storCount) 
                {
                    foreach(GameObject g in gameData.tempStorages)
                    {
                         curTempStorage.Enqueue(g);
                         storCount++;
                         if(gameData.tempStorages.Count == storCount) break;
                    }
                   
                }
                if (curTempStorage.Count == 0)
                {
                    rb.velocity = new Vector2(0, 0);
                    StartCoroutine(Folding());
                    yield break;
                }
                yield return new WaitForSeconds(0.5f);
            }
            
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Folding()
    {
        while (true) 
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
            rb.velocity = new Vector2(0, -Speed);
            if (hit != false)
            {
                if (hit.collider.gameObject.layer == 12)
                {
                    rb.velocity = new Vector2(0, 0);
                    yield return new WaitForSeconds(1f);
                    gameData.LocalPoints += carrying;
                    carrying = 0;
                    StartCoroutine(Collecting());
                    yield break;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

}