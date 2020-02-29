using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bridgePrefab;
    private GameObject _bridge;
    private void OnBecameVisible() // Создание моста
    {
        _bridge = Instantiate(bridgePrefab) as GameObject; 
        _bridge.transform.position = transform.position;
    }
    private void OnBecameInvisible() // Уничтожение
    {
        Destroy(_bridge);
    }
}
