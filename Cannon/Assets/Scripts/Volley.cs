using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volley : MonoBehaviour
{
   public GameObject shell;

  public void Launch()
  {
    float distance =  Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    Debug.Log(distance);
    GameObject missle = Instantiate(shell, transform.position, Quaternion.Euler(0,0,0)) as GameObject;
    missle.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(transform.position.x - distance), 5f);
  }
}
