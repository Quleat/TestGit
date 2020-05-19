using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceStorageRed : MonoBehaviour
{
    public int minerType = 0;
    public int income = 5;
    public int upgradeCost = 20;
    public int addCost = 40;
    public float speed = 1f;
    public float digTime = 1f; 
    public GameObject minerPrefab;
    public GameObject platform;
    public Transform spawnPosition;
    public Text upgradeText;
    public Text addNewText;
    public LayerMask whatIsWall;
    public TempStorage  tempStorage;
    void Awake()
    {
         Debug.Log("+");
        //var ts = Type.GetType("TempStorage");
        //gameObject.AddComponent(ts);
        //TempStorage st = gameObject.AddComponent(typeof(TempStorage)) as TempStorage; 
        tempStorage = new TempStorage(minerType, income, upgradeCost, addCost,speed, digTime, minerPrefab, platform, spawnPosition, upgradeText, addNewText, whatIsWall);
        gameData.tempStorages.Enqueue(gameObject);
    }
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
    }
    public void addNew()
    {
        tempStorage.AddNew();
    }
}
