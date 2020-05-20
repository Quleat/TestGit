using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class gameData
{
    public static Queue<GameObject> tempStorages = new Queue<GameObject>();
    public static int[] TempStoragePoints = new int[3];

    public static Text GeneralPointsText;
    public static Text LocalPointsText;
    public static Text[] TempPointsText = new Text[3];

    public static int _localPoints = 0;
    public static int _generalPoints = 100;
    public static int LocalPoints

    {
        get
        {
            return _localPoints;
        }
        set
        {
            _localPoints = value;
            LocalPointsText.text = _localPoints.ToString();
        }
    }

    public static int GeneralPoints
    {
        get
        {
            return _generalPoints;
        }
        set
        {
            _generalPoints = value;
            GeneralPointsText.text = _generalPoints.ToString();
        }
    }

    public static void ChangeTempPoints(int value, int num)
    {
        TempStoragePoints[num] = value;
        TempPointsText[num].text = TempStoragePoints[num].ToString();
    }
    public static void ClearTempPoints(int num)
    {
        TempStoragePoints[num] = 0;
        TempPointsText[num].text = "0";
    }
}
