using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int points = 0;
    public static Text _text;
    public Text text;
    public static int amount = 10;

    void Start()
    {
        _text = text;
    }
    public static void AddPoints()
    {
        points += amount;
        _text.text = points.ToString();
    }
    public void IncreaseAmount()
    {
        if (points >= (amount * 3)) 
        {
            points -= amount * 3;
            amount *= 2;
            _text.text = points.ToString();
        }
    }
}
