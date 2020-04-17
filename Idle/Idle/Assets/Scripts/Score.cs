using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{ 
    public static Text _text;
    public static Slider _slider;
    public Text text;
    public Slider slider;
    public static int amount = 10;

    private bool maxMushrooms = false;

    public GameObject platformPrefab;
    public GameObject mushroomPrefab;

    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        _text = text;
        _slider = slider;
        DontDestroyOnLoad(gameObject);
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
    public void AddNewOne()
    {
        if (gameData.points >= 20)
        {
            GameObject _platform = Instantiate(platformPrefab) as GameObject;
            _platform.transform.position = new Vector3(-3.7f, -0.48f, 0);
            GameObject _mushroom = Instantiate(mushroomPrefab) as GameObject;
            _mushroom.transform.position = new Vector3(-4f, -0.28f, 0);
            gameData.points -= 20;
            maxMushrooms = true;
            _text.text = gameData.points.ToString();
        }
    }
}
