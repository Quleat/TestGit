using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    private GameObject Player;
    public GameObject ThisRunner;
    public GameObject Check;
    public GameObject Check2;

    public LayerMask WhatIsPlatform;

    private Rigidbody2D RunnerRB;

    public bool OnGround;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        RunnerRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Jumping();
        MovingCloser();
    }
    //void Jumping()
    //{
    //    if(Player.transform.position.y - ThisRunner.transform.position.y <= 0.1)
    //    {
    //        bool SomethingAbove = Physics2D.OverlapCircle(Check.transform.position, 0, WhatIsPlatform);
    //        OnGround = Physics2D.OverlapCircle(Check2.transform.position, 0, WhatIsPlatform);
    //        if(SomethingAbove && OnGround)
    //        {
    //            RunnerRB.AddForce(new Vector2(RunnerRB.velocity.x, 600));
    //        }
    //    }
    //}
    void MovingCloser()
    {
        RunnerRB.velocity = new Vector2(-1f, RunnerRB.velocity.y);
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
