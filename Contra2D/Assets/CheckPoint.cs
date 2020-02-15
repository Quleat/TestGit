using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public LayerMask WhatIsPlayer;

    [SerializeField] public GameObject Player;

    public GameObject Check;
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
    public void Respawn()
    {
        GameObject Player1 = Instantiate(Player) as GameObject;
        if (Test.PassedCheckpoint)
        {
            Player1.transform.position = new Vector3(0.5f, 1, -0.01f);
        }
        else
        {
            Player1.transform.position = new Vector3(-10, 1, -0.01f);
        }
    }
}
