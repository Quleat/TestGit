using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int score;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.6f);
    }
    public void PutScoreInBox(int score)
    {
        this.score = score;
    }
    public void PutScoreIntBox(int minScore, int maxScore)
    {
        score = Random.Range(minScore, maxScore + 1);
    }
    public void OpenBox()
    {
        //Resources.score += score;
        Destroy(gameObject);
    }
}
