using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomTest : MonoBehaviour
{
    //public int MinerType;         
    //Rigidbody2D rb;
    //public LayerMask WhatIsWall;
    //public bool dig = false;
    //public MushRoom mushRoom;

    //public GameObject _minerPrefab;

    //public float digTime = 0;
    //public float speed = 0;

    //public Vector3 spawnPoint;

    //private bool digging = false;
    //private float curTime = 0;

    //private int curScore = 0;
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    mushRoom = new MushRoom(Miner.IncomeRed, Miner.digTimeRed, Miner.SpeedRed, transform, WhatIsWall, 0.1f, rb, Vector3.right);
    //    rb.velocity = new Vector2(1, 0);
    //}

    //private void Update()
    //{
    //    Mine(speed, digTime);
    //}
    //public bool Mine(float speed, float digTime)
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.5f, WhatIsWall);
    //    if (hit)
    //    {
    //        Debug.Log("+");
    //        if (hit.collider.gameObject.tag == "1st")
    //        {
    //            Debug.Log("-");
    //            curScore += hit.collider.gameObject.GetComponent<MushRoomRed>().income;
    //            Debug.Log(hit.collider.gameObject.GetComponent<MushRoomRed>().income);
    //            Rotate();
    //            return true;
    //        }
    //        else
    //        {
    //            gameData.TempStoragePoints[0] += curScore;
    //            gameData.TempPointsText[0].text = curScore.ToString();
    //            curScore = 0;
    //            if (!digging)
    //            {
    //                rb.velocity = new Vector2(0, 0);
    //                digging = true;
    //                curTime = 0;
    //            }
    //            curTime += Time.deltaTime;
    //            if (curTime >= digTime)
    //            {
    //                digging = false;
    //                Rotate();
    //            }
    //        }
    //    }
    //    else
    //    {
    //        rb.velocity = transform.TransformDirection(Vector2.right * speed * Time.deltaTime);
    //    }
    //    return false;
    //}
    //private void Rotate()
    //{
    //    transform.Rotate(new Vector3(0, 180, 0), Space.Self);
    //    rb.velocity = transform.TransformDirection(Vector2.right * speed * Time.deltaTime);
    //}
    //public void AddNew()
    //{
    //    GameObject _newMiner = Instantiate(_minerPrefab) as GameObject;
    //    _newMiner.transform.position = spawnPoint;
    //}
}
