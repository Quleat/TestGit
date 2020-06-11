using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volley : MonoBehaviour
{
  public GameObject shell;
  public void Update()
  {
    if(Input.GetMouseButtonDown(0))
    {
      Launch();
    }
  }
  public void Launch()
  {
    float distance =  Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x);
    //Debug.Log(distance);
    GameObject missle = Instantiate(shell, transform.position, Quaternion.Euler(0,0,0)) as GameObject;
    missle.GetComponent<ShellSc>().activate(distance, Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
  }
}
