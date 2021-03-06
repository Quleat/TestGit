﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TempStorage : MonoBehaviour
{
    public int minerType;
    public int income = 5;
    private int upgradeCost = 20;
    private int addCost = 30;
    private int level = 1;
    private int incomeBoost = 1;
    private int speedBoost = 1;
    private int digBoost = 1;
    public float speed = 0.1f;
    public float digTime = 5f;
    public float boostDuration = 30f;

    private bool activeBoost = false;

    public GameObject minerPrefab;
    public GameObject platform;

    public Transform spawnPosition;

    public Text upgradeText;
    public Text AddNewText;
    public LayerMask whatIsWall = LayerMask.GetMask("wall");
    public  TempStorage(int minerType, int income, int upgradeCost, int addCost, float speed, float digTime, GameObject minerPrefab, GameObject platform, Transform spawnPosition, Text upgradeText, Text AddNewText, LayerMask whatIsWall)
    {
        this.minerType = minerType;
        this.upgradeCost = upgradeCost;
        this.addCost = addCost;
        this.speed = speed;
        this.digTime = digTime;
        this.minerPrefab = minerPrefab;
        this.platform = platform;
        this.spawnPosition = spawnPosition;
        this.upgradeText = upgradeText;
        this.AddNewText = AddNewText;
        this.whatIsWall = whatIsWall;
    }

    public void AddPoints()
    {
        gameData.ChangeTempPoints(income * incomeBoost, minerType);
    }
    public void AddNew()
    {
        if (gameData.GeneralPoints >= addCost)
        {
            gameData.GeneralPoints -= addCost;
            GameObject _miner = Instantiate(minerPrefab, spawnPosition.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            addCost *= 2;
            UpdateAddNewButton();
        }
    }
    public void UpgradeMiner()
    {
        if (gameData.GeneralPoints >= upgradeCost)
        {
            gameData.GeneralPoints -= upgradeCost;
            income = (int)(income *1.5f);
            speed *= 1.5f;
            upgradeCost *=(int) 2;
            level++;
            UpdateUpgradeButton();
        }
    }
    public void UpdateUpgradeButton()
    {
        upgradeText.text = $"Upgrade \n Level: {level} +1\n Income: {income} + {(int)(income * 0.5f)}\n Cost: {upgradeCost} + {upgradeCost * 2}";
    }
    public void UpdateAddNewButton()
    {
        AddNewText.text = $"Buy a new one \n {addCost}";
    }

    public void activateDigBoost()
    {
        
            StartCoroutine(workingBoost(digBoost));
    }
    public void activateIncomeBoost()
    {
            StartCoroutine(workingBoost(incomeBoost));
    }
    public void acitvateSpeedBoost()
    {
            StartCoroutine(workingBoost(speedBoost));
    }
    private IEnumerator workingBoost(float boost)
    {
        if (!activeBoost)
        {
            activeBoost = true;
            boost *= 2;
            yield return new WaitForSeconds(boostDuration);
            boost = 1;
            activeBoost = false;
        }
    }
}
