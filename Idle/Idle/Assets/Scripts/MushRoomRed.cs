using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomRed : MushRoom
{
    public int minerType = 2;

    public LayerMask _whatIsWall;

    public float _distance = 0.1f;

    Rigidbody2D _rb;

    MushRoom mushRoom;
    void Awake()
    {
        _whatIsWall = LayerMask.GetMask("wall");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 100f, _whatIsWall);
        GameObject _tempStorage = hit.collider.gameObject;
        TempStorage ts = _tempStorage.GetComponent<TempStorage>();
        _rb = GetComponent<Rigidbody2D>();
        Initialize(5, 1f, 0.1f, _whatIsWall, 0.1f, _rb, _tempStorage);
        StartCoroutine(active());
    }
}