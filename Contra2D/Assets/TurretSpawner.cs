using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;
    private GameObject turret;
    private void OnBecameVisible()
    {
        if (turret == null)
        {
            Debug.Log("Турель создана");
            turret = Instantiate(turretPrefab) as GameObject;
            turret.transform.position = transform.position;
        }
    }
    private void OnBecameInvisible()
    {
        if(turret != null)
        {
            Destroy(turret);
        }
    }
}
