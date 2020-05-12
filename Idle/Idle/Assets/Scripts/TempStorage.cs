using System.Collections;
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
    private int moneyBoost = 1;

    public float speed = 0.1f;
    public float digTime = 5f;
    public float boostDuration = 30f;

    private bool activeBoost = false;

    public GameObject minerPrefab;

    public Transform spawnPosition;

    public Text upgradeText;
    public Text AddNewText;
    void Start()
    {
        
    }
    public void AddPoints()
    {
        gameData.ChangeTempPoints(income * moneyBoost, minerType);
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
            upgradeCost *= 2;
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
    private IEnumerator activateBoost()
    {
        activeBoost = true;
        yield return new WaitForSeconds(boostDuration);
    }
}
