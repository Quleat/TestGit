using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float points = 0;
    public static Text text;
    public Text _text;
    void Start()
    {
        text = _text;
    }
    public static void AddScore(float newPoints)
    {
        points += newPoints;
        text.text = points.ToString();
    }
}