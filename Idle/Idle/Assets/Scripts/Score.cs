using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Text _text;
    public static Text generalPoints;
    public Text text;
    public Text _generalPoints;
    public Text[] minerUpgradeText = new Text[3];
    public Text[] minerBuyNewText = new Text[3];
    //public Text[] minerStats = new Text[3];
    public static Text[] storageTexts = new Text[3];
    public Text[] _storageTexts = new Text[3];
    public static Text collectorText;
    public Text _collectorText;

    public Slider slider;
    public static Slider _slider;

    public GameObject platformPrefab;
    public GameObject mushroomPrefab;
    public GameObject[] miners = new GameObject[3];
    public GameObject[] minerPrefabs = new GameObject[3];
    public GameObject[] minerUpgradeButton = new GameObject[3];
    public GameObject[] minerBuyNewButton = new GameObject[3];

    public int[] minerAmount = { 40, 70, 100 };
    private int[] minerStatsLevel = { 1, 1, 1 };
    public static int[] tempStorage = { 10, 20, 30 };
    public static float collectorSpeed = 0.5f;
    public int collectorCost = 60;

    public Transform[] minerSpawns = new Transform[3];

    CarrierSc carrier;

    public bool[] active1 = new bool[3];
    public bool[] active2 = new bool[3];
    public bool[] active3 = new bool[3];
    void Start()
    {
        carrier = GameObject.FindGameObjectWithTag("carrier").GetComponent<CarrierSc>();
        collectorText = _collectorText;
        generalPoints = _generalPoints;
        storageTexts = _storageTexts;
        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        _text = text;
        _slider = slider;
        Physics2D.IgnoreLayerCollision(9, 9);
        for (int i = 0; i < minerUpgradeText.Length; i++)
        {
            minerBuyNewText[i].text = "Buy a new one: " + minerAmount[i].ToString();
        }
    }
    public static void AddPoints(int minerType)
    {
            tempStorage[minerType] += (gameData.minerLevel[minerType] );
            storageTexts[minerType].text = tempStorage[minerType].ToString();
    }
    public static void ClearStorage(int minerType)
    {
        tempStorage[minerType] = 0;
        storageTexts[minerType].text = tempStorage[minerType].ToString();
    }
    public static void AddCollectorPoints(int value)
    {
        gameData.points += value;
        _text.text = gameData.points.ToString();
    }
    public void AddNewOne(int minerType)
    {
        if (gameData.generalPoints >= minerAmount[minerType])
        {
            if (!miners[minerType].activeSelf)
            {
                miners[minerType].SetActive(true);
                if (minerType > 0)
                {
                    minerUpgradeButton[minerType].SetActive(true);
                }
            }
            else
            {
                GameObject _newMiner = Instantiate(minerPrefabs[minerType], new Vector3(minerSpawns[minerType].position.x, minerSpawns[minerType].position.y, minerSpawns[minerType].position.z), Quaternion.Euler(0, 0, 0)) as GameObject;
            }
            gameData.generalPoints -= minerAmount[minerType];
            minerAmount[minerType] *= 2;
            minerBuyNewText[minerType].text = "Buy a new one: " + minerAmount[minerType].ToString();
            generalPoints.text = gameData.generalPoints.ToString();
        }
    }
    public void UpgradeMiner(int minerType)
    {
        if (gameData.generalPoints >= gameData.minerLevel[minerType] * 3)
        {
            int Newincome = 0;
                minerStatsLevel[minerType]++;
                gameData.generalPoints -= gameData.minerLevel[minerType] * 3;
                if (minerStatsLevel[minerType] == 24 || minerStatsLevel[minerType] == 49 || minerStatsLevel[minerType] == 99)
                {
                Newincome = gameData.minerLevel[minerType] * 3;
                }
                else if(minerStatsLevel[minerType] == 25 || minerStatsLevel[minerType] == 50 || minerStatsLevel[minerType] == 100)
                {
                gameData.minerLevel[minerType] *= 4;
                Newincome = gameData.minerLevel[minerType];
                }
                else 
                {
                gameData.minerLevel[minerType] *= 2;
                Newincome = gameData.minerLevel[minerType];
                }

                if (gameData.minerSpeed[minerType] < 2) gameData.minerSpeed[minerType] *= 2;
                minerUpgradeText[minerType].text = ($"Level: {minerStatsLevel[minerType]} +{1}\n" + $" Upgrade: {gameData.minerLevel[minerType] * 3} +{gameData.minerLevel[minerType] * 3}\n" + $" Income: {gameData.minerLevel[minerType]} +{Newincome}");
        }
       generalPoints.text = gameData.generalPoints.ToString();
    }
    public void Test(int money)
    {

    }
    public void UpgradeCollector()
    {
        if(gameData.generalPoints >= collectorCost)
        {
            if (collectorSpeed < 2)
            {
                gameData.generalPoints -= collectorCost;
            }
                collectorCost *= 2;
                collectorSpeed += 0.2f;
                collectorText.text = $"Upgrade collector: {collectorCost.ToString()}";
                UpdateMoney();
        }
    }
    public static void AddGeneralPoints(int value)
    {
        gameData.generalPoints += value;
        UpdateMoney();
    }
    public void SendCarrier()
    {
        carrier.Send();
    }
    public void ActivateBoost(int type)
    {
        int minerType = (type % 10) -1;
        type /= 10;
        StartCoroutine(ActivateCorotineBoost(type, minerType));
    }
    public static void UpdateMoney()
    {
        _text.text = gameData.points.ToString();
        generalPoints.text = gameData.generalPoints.ToString();
    }
    IEnumerator ActivateCorotineBoost(int type, int minerType)
    {
        if(active1[minerType] && type == 1)
        {
            type = 0;
        }
        if (active2[minerType] && type == 2)
        {
            type = 0;
        }
        if (active3[minerType] && type == 3)
        {
            type = 0;
        }
        float _statBefore = 0;
       
            if (type == 1)
            {
                _statBefore = Miners.digTime[minerType];
                Miners.digTime[minerType] = 0;
                Debug.Log("+");
                active1[minerType] = true;
            }
            else if(type == 2)
            {
                _statBefore = gameData.minerSpeed[minerType];
                gameData.minerSpeed[minerType] *= 2;
                active2[minerType] = true;
            }
            else if(type == 3)
            {
                _statBefore = gameData.minerLevel[minerType];
                gameData.minerLevel[minerType] *= 3;
                active3[minerType] = true;
            }
        
        yield return new WaitForSeconds(60f);
       
            if (type == 1)
            {
                Miners.digTime[minerType] = _statBefore;
                active1[minerType] = false;
            }
            else if(type == 2)
            {
                gameData.minerSpeed[minerType] = _statBefore;
                active2[minerType] = false;
            }
            else if(type == 3)
            {
                gameData.minerLevel[minerType] = (int)_statBefore;
                active3[minerType] = false;
            }
    }
}
