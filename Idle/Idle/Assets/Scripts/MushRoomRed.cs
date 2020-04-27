using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomRed : MonoBehaviour
{
    public int MinerType;
    Rigidbody2D rb;
    public LayerMask WhatIsWall;
    public bool dig = false;
    public MushRoom mushRoom;
    public GameObject[] minerUpgradeButton = new GameObject[3];

    private Transform _transform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mushRoom = new MushRoom(5, 1f, 5f, transform, WhatIsWall, 0.1f, rb, Vector3.right);
        rb.velocity = new Vector2(1, 0);

        _transform = transform; 
    }
    void FixedUpdate()
    {
        if (mushRoom.Mine())
        {
            gameData.ChangeTempPoints(mushRoom.Income, MinerType);
        }
    }
    public void UpgradeMiner()
    {
        if (gameData.GeneralPoints >= mushRoom.Income * 3)
        {
            mushRoom.Upgrade();
            gameData.GeneralPoints -= mushRoom.Income * 3;
        }
    }
}
//RaycastHit2D hit = Physics2D.Raycast(_transform.position, _transform.TransformDirection(Vector2.right), 0.1f, WhatIsWall);
//        if (hit && !dig)
//        {
//            if (hit.collider.gameObject.tag == "1st")
//            {
//                gameData.ChangeTempPoints(mushRoom.Income, minerType);
//                _transform.Rotate(new Vector3(0, 180, 0), Space.Self);
//            }
//            else
//            {
//                StartCoroutine(Diging());
//            }
//        }
//        else
//        {
//            rb.velocity = _transform.TransformDirection(Vector2.right* mushRoom.Speed);
//        }
//        IEnumerator Diging()
//{
//    dig = true;
//    rb.velocity = new Vector2(0, 0);
//    yield return new WaitForSeconds(mushRoom.DigTime);
//    _transform.Rotate(new Vector3(0, 180, 0), Space.Self);
//    dig = false;
//}


