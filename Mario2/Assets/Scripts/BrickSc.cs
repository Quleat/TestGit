using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSc : MonoBehaviour
{
    public GameObject item;
    private Animator anim;
    public Sprite destroied;
    private SpriteRenderer sr;
    public bool itIsRandomBrick;
    void Start()
    {
        if (itIsRandomBrick) anim = GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    public void activation()
    {
        if (itIsRandomBrick)
        {
            GameObject _item = Instantiate(item) as GameObject;
            _item.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
        }
        Destroy(gameObject, 0.1f);
    }
}
