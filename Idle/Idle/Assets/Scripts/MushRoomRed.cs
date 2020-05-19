using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomRed : MonoBehaviour
{
    public int minerType = 2;

    public LayerMask whatIsWall;

    public float distance = 0.1f;

    Rigidbody2D rb;

    Mushroom mushroom;
    void Start()
    {
        SaveLoad.Mushrooms.Add(gameObject);
        rb = GetComponent<Rigidbody2D>();
        whatIsWall = LayerMask.GetMask("wall");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 100f, whatIsWall);
        GameObject _resourceStorage = hit.collider.gameObject;
        TempStorage ts = _resourceStorage.GetComponent<ResourceStorageRed>().tempStorage;
        mushroom = new Mushroom(ts.income, ts.digTime, ts.speed, whatIsWall, distance, rb, ts);
        StartCoroutine(mushroom.active());
    }
}