using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : Enemy
{
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Move();
    }
}
