using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public LayerMask WhatIsWater;
    public LayerMask WhatIsPlatform;

    public bool isWater;
    public Transform check;
    public bool OnGround;
    public Transform check2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isWater = Physics2D.OverlapCircle(check.position, 0, WhatIsWater);
        OnGround = Physics2D.OverlapCircle(check.position, 0, WhatIsPlatform);
        Collider2D[] platformUp = Physics2D.OverlapCircleAll(check2.position, 0, WhatIsPlatform);
        foreach(Collider2D item in platformUp)
        {
            BoxCollider2D bc = item.GetComponent<BoxCollider2D>();
            bc.isTrigger = true;
        }
        Collider2D[] platformDown = Physics2D.OverlapCircleAll(check.position, 0, WhatIsPlatform);
        foreach (Collider2D item in platformDown)
        {
            BoxCollider2D bc = item.GetComponent<BoxCollider2D>();
            
            if(Input.GetKey(KeyCode.S)) 
            { 
                bc.isTrigger = true;
            }
            else
            {
                bc.isTrigger = false;
            }
        }

    }
}
