using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameData : MonoBehaviour
{
    public static int points = 0;
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
