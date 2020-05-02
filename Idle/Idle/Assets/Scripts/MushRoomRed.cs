using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomRed : MonoBehaviour
{
    public int MinerType = 2;

    public LayerMask WhatIsWall;

    public float distance = 0.1f;

    Rigidbody2D rb;

    MushRoom mushRoom;

    public GameObject tempStorage;

    void Start()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 100f, WhatIsWall);
        tempStorage = hit.collider.gameObject;
        rb = GetComponent<Rigidbody2D>();
        mushRoom = new MushRoom(20, 3f, 0.2f, transform, WhatIsWall, distance, rb, tempStorage);
    }
    void FixedUpdate()
    {
        mushRoom.Mine(Miner.SpeedGreen, Miner.SpeedGreen);
    }
    public void UpgradeMiner()
    {
        if (gameData.GeneralPoints >= Miner.IncomeGreen * 1)
        {
            gameData.GeneralPoints -= Miner.IncomeGreen * 1;
        }
    }
}