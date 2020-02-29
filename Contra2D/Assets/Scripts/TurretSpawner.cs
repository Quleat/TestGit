using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;
    private GameObject _turret;
    private void OnBecameVisible()
    {
        if (_turret == null)
        {
            Debug.Log("Турель создана");
            _turret = Instantiate(turretPrefab) as GameObject;
            _turret.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1); ;
        }
    }
    private void OnBecameInvisible()
    {
        if(_turret != null)
        {
            Destroy(_turret);
        }
    }
}
