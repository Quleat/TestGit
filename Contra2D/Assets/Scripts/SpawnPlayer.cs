using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public bool PassedCheckpoint = false;
    public bool died = false;

    public static int RemainLives = 3;

    [SerializeField] private GameObject _playerPrefab;
    void Start()
    {

    }
    public void Respawn()
    {
        GameObject Player1 = Instantiate(_playerPrefab) as GameObject;
        if (PassedCheckpoint)
        {
            Player1.transform.position = new Vector3(0.5f, 1, -0.01f);
        }
        else
        {
            Player1.transform.position = new Vector3(-10, 1, -0.01f);
        }
    }
}
