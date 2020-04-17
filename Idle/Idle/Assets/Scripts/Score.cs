using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int points = 0;
    public static Text _text;
    public static Slider _slider;
    public Text text;
    public Slider slider;
    public static int amount = 10;

    void Start()
    {
        text = 
        _text = text;
        _slider = slider;
        DontDestroyOnLoad(this);
    }
    public static void AddPoints()
    {
        gameData.points += amount;
        _text.text = gameData.points.ToString();
    }
    public void IncreaseAmount()
    {
        if (gameData.points >= (amount * 3)) 
        {
            gameData.points -= amount * 3;
            amount *= 2;
            _text.text = gameData.points.ToString();
        }
    }
    public void IncreaseProgress()
    {
        _slider.value += (gameData.points / 10);
        gameData.points %= 10;
        _text.text = gameData.points.ToString();
        if (slider.value >= slider.maxValue) SceneManager.LoadScene(1);
    }
}
