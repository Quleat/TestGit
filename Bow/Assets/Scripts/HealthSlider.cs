using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSlider : MonoBehaviour
{
    public Enemy Target { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Target == null) return;
        Vector3 newPos = Camera.main.WorldToScreenPoint(Target.transform.position);
        
        GetComponent<RectTransform>().position = newPos;

    }
}
