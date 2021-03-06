﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text _text;
    public Text _generalPoints;
    public Text[] minerUpgradeText = new Text[3];
    public Text[] minerBuyNewText = new Text[3];
    //public Text[] minerStats = new Text[3];
    public static Text[] storageTexts = new Text[3];
    public Text[] _storageTexts = new Text[3];
    public static Text collectorText;
    public Text _collectorText;

    public int[] minerAmount = { 40, 70, 100 };
    private int collectorCost = 60;

    CarrierSc carrier;
    void Start()
    {
        carrier = GameObject.FindGameObjectWithTag("carrier").GetComponent<CarrierSc>();
        gameData.LocalPointsText = _text;
        gameData.GeneralPointsText = _generalPoints;
        collectorText = _collectorText;
        storageTexts = _storageTexts;
        Physics2D.IgnoreLayerCollision(9, 9);
        for (int i = 0; i < minerUpgradeText.Length; i++)
        {
            minerBuyNewText[i].text = "Buy a new one: " + minerAmount[i].ToString();
        }
        for (int i = 0; i < gameData.TempPointsText.Length; i++)
        {
            gameData.TempPointsText[i] = _storageTexts[i];
        }
        gameData.GeneralPointsText.text = gameData._generalPoints.ToString(); // На всякий случай
    }
    public void UpgradeCollector()
    {
        if (gameData.GeneralPoints >= collectorCost)
        {
            if (collector.Speed < 2)
            {
                gameData.GeneralPoints -= collectorCost;
            }
            collectorCost *= 2;
            collector.Speed += 0.2f;
            collectorText.text = $"Upgrade collector: {collectorCost.ToString()}";
        }
    }
    public void SendCarrier()
    {
        carrier.Send();
    }
}
//public void ActivateBoost(int type)
//{
//    int minerType = (type % 10) - 1;
//    type /= 10;
//    StartCoroutine(ActivateCorotineBoost(type, minerType));
//}
//IEnumerator ActivateCorotineBoost(int type, int minerType)
//{
//    if (active1[minerType] && type == 1)
//    {
//        type = 0;
//    }
//    if (active2[minerType] && type == 2)
//    {
//        type = 0;
//    }
//    if (active3[minerType] && type == 3)
//    {
//        type = 0;
//    }
//    float _statBefore = 0;

//    if (type == 1)
//    {
//        _statBefore = Miners.digTime[minerType];
//        Miners.digTime[minerType] = 0;
//        Debug.Log("+");
//        active1[minerType] = true;
//    }
//    else if (type == 2)
//    {
//        _statBefore = gameData.minerSpeed[minerType];
//        gameData.minerSpeed[minerType] *= 2;
//        active2[minerType] = true;
//    }
//    else if (type == 3)
//    {
//        _statBefore = gameData.minerLevel[minerType];
//        gameData.minerLevel[minerType] *= 3;
//        active3[minerType] = true;
//    }

//    yield return new WaitForSeconds(60f);

//    if (type == 1)
//    {
//        Miners.digTime[minerType] = _statBefore;
//        active1[minerType] = false;
//    }
//    else if (type == 2)
//    {
//        gameData.minerSpeed[minerType] = _statBefore;
//        active2[minerType] = false;
//    }
//    else if (type == 3)
//    {
//        gameData.minerLevel[minerType] = (int)_statBefore;
//        active3[minerType] = false;
//    }
//}




