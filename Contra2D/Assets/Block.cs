using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    public Color colorFromUnity;
    private Color currentColor;
    private Color clearColor = new Color(1,1,1,1);
    private bool _isClear;
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        currentColor = clearColor;
    }
    void FixedUpdate()
    {
        if (_isClear)
        {
            currentColor = Color.Lerp(currentColor, clearColor, Time.deltaTime);
        }
        _renderer.color = currentColor;
    }
    public void OnClick()
    {
        Debug.Log("Click"); 
    }
    public void OnEnter()
    {
        currentColor = colorFromUnity;
        _isClear = false;
        Debug.Log("Enter");
    }
    public void OnExit()
    {
        Debug.Log("Exit");
        _renderer.color = clearColor;
        _isClear = true;
    }
}
