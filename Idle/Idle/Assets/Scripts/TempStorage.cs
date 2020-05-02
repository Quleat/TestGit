using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempStorage : MonoBehaviour
{
    public int minerType;
    public int income;
    public void AddPoints()
    {
        gameData.ChangeTempPoints(income, minerType);
    }
}
