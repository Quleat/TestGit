using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomBrown : MonoBehaviour
{
    public int minerType;

    MushRoom mushRoom;

    Rigidbody2D rb;

    LayerMask whatIsWall;

    private GameObject tempStorage;
    void Start()
    {
        whatIsWall = LayerMask.GetMask("wall");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 100f, whatIsWall);
        tempStorage = hit.collider.gameObject;
        rb = GetComponent<Rigidbody2D>();
        //mushRoom = new MushRoom(Miner.IncomeBrown, Miner.digTimeBrown, Miner.SpeedBrown, transform, whatIsWall,0.1f, rb, tempStorage);
    }
    private void FixedUpdate()
    {
        mushRoom.Mine();
    }
    public void UpgradeMiner()
    {
        //if (gameData.GeneralPoints >= Miner.IncomeBrown * 1)
        //{
         //   gameData.GeneralPoints -= Miner.IncomeBrown* 1;
        //}
    }
}
