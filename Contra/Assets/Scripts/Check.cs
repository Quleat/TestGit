using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public LayerMask WhatIsWater;
    public bool isWater;
    public Transform check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isWater = Physics2D.OverlapCircle(check.position, 0, WhatIsWater);
        
    }
}
