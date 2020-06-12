using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    static public float hp = 5f;
    static public void GetDamage(float damage)
    {
        hp -= damage;
        if(hp < 0) 
        {
            Debug.Log("Game Over");
        }
    }
}
