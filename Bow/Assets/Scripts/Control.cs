using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    float mouseY;
    public float damage = 1;
    public float sensitivity = 1f;
    public float arrowSpeed = 1f;
    public float fireRate = 0.5f;

    bool fireButton;

    public GameObject arrowPrefab;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Shooting());
    }

    void Update()
    {
        GetInput();
        MouseControl();
    }
    void MouseControl()
    {
        rb.velocity = new Vector2(0, mouseY * sensitivity);
    }
    void Shoot()
    {
        GameObject _arrow = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(0,0,0));
        _arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(1,0);
        _arrow.GetComponent<Arrow>().damage = damage;
    }
    void GetInput()
    {
        mouseY = Input.GetAxis("Mouse Y");
        fireButton = Input.GetMouseButtonDown(0);
    }
    IEnumerator Shooting()
    {
        while(true)
        {
        if(fireButton)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
        yield return null;
        }
    }
}
