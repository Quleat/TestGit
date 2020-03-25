using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBrick : MonoBehaviour
{
    public GameObject item;
    public bool activated;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void activation()
    {
        GameObject _item = Instantiate(item) as GameObject;
        _item.transform.position = transform.position;
        Destroy(gameObject);
    }
}
