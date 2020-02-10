using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public LayerMask WhatIsPlayer;

    public GameObject Check;
    void Start()
    {
        
    }
    void Update()
    {
        //Test.PassedCheckpoint = Physics2D.OverlapCircle(Check.transform.position, 0, WhatIsPlayer)
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Test.PassedCheckpoint = true;
        }
    }
}
