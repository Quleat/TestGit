using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomGreen : MonoBehaviour
{
    public int minerType = 2;

    Rigidbody2D rb;
    
    public LayerMask watIsWall;

    public float distance = 0.1f;

    private GameObject tempStorage;
    void Start()
    {
        watIsWall = LayerMask.GetMask("wall");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left,100f, watIsWall);
        tempStorage = hit.collider.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {

    }
    public void UpgradeMiner()
    {
       // if (gameData.GeneralPoints >= Miner.IncomeGreen * 1)
        //{
        //    gameData.GeneralPoints -= Miner.IncomeGreen * 1;
        //}
    }
}
