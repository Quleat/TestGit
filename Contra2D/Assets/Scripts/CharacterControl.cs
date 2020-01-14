using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Rigidbody2D Character;
    public Rigidbody2D bp;
    public float inputx;
    public float speed = 50f;
    public float thrust = 100f;
    Check check;
    public GameObject Bullet;
    public Transform player;
    public Transform Cm;
    void Start()
    {
        Character = GetComponent<Rigidbody2D>();

        check = FindObjectOfType<Check>();
    }
   void Update()
    {
        inputx = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(inputx, Character.velocity.y) * Time.deltaTime * speed;
        Character.velocity = movement;
        if (Input.GetKeyDown(KeyCode.W) && check.OnGround) Character.AddForce(new Vector2(0,600));
        if(Input.GetKeyDown(KeyCode.F))
        {
            GameObject Bulletprefab = Instantiate(Bullet) as GameObject;
            Bulletprefab.transform.position = player.position;
            bp = Bulletprefab.GetComponent<Rigidbody2D>();
            bp.AddForce(new Vector2(20, 0) * Time.deltaTime);
        }
        if ((player.position.x) >= -7.7) { Cm.transform.position = new Vector3(player.position.x, Cm.transform.position.y, -1); }
        
    }
}
