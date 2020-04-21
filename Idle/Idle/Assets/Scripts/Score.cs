using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Text _text;
    public Text text;
    public Text[] minerUpgradeText = new Text[3];
    public Text[] minerBuyNewText = new Text[3];
    public Text[] minerStats = new Text[3];
    public static Text[] storageTexts = new Text[3];
    public Text[] _storageTexts = new Text[3];

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
    public static int[] tempStorage = { 0, 0, 0 };

    public Transform[] minerSpawns = new Transform[3];

    void Start()
    {
        storageTexts = _storageTexts;
        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        _text = text;
        _slider = slider;
        Physics2D.IgnoreLayerCollision(9, 9);
        for (int i = 0; i < minerUpgradeText.Length; i++)
        {
            //minerUpgradeText[i].text = "Upgrade: " + (gameData.minerLevel[i] * 3).ToString();
            minerBuyNewText[i].text = "Buy a new one: " + minerAmount[i].ToString();
        }
    }
    public static void AddPoints(int minerType)
    {
            tempStorage[minerType] += (gameData.minerLevel[minerType] );
            storageTexts[minerType].text = tempStorage[minerType].ToString();
    }
    public void AddNewOne(int minerType)
    {
        if (gameData.points >= minerAmount[minerType])
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
            gameData.points -= minerAmount[minerType];
            minerAmount[minerType] *= 2;
            minerBuyNewText[minerType].text = "Buy a new one: " + minerAmount[minerType].ToString();
            _text.text = gameData.points.ToString();
        }
    }
    public void UpgradeMiner(int minerType)
    {
        //if (gameData.points >= gameData.minerLevel[minerType] * 3)
        //{
            int Newincome = 0;
                minerStatsLevel[minerType]++;
                gameData.points -= gameData.minerLevel[minerType] * 3;
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
        //}
        _text.text = gameData.points.ToString();
    }
    public void Test()
    {

    }
}
