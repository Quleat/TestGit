using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomGreen : MonoBehaviour
{
    public int MinerType = 2;
    Rigidbody2D rb;
    public LayerMask WhatIsWall;
    public float distance = 0.1f;
    MushRoom mushRoom;


    void Start()
    {
       mushRoom = new MushRoom(20, 3f, 0.2f, transform, WhatIsWall, distance, rb,Vector3.right);
    }
    void FixedUpdate()
    {
        if(mushRoom.Mine())
        {
            gameData.ChangeTempPoints(mushRoom.Income, MinerType);
        }
    }
}
