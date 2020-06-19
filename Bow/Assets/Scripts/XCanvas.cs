using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class XCanvas : MonoBehaviour
{
    public GameObject pauseMenu;
    public List<GameObject> enemiesPrefabs = new List<GameObject>();
    public GameObject NextLevelButton;

    public Control control;
    public Arrow arrow;

    static public float points = 1f;
    public int requiredProgress = 10;
    public int curLevel = 0;

    public Text pointsText;
    public Slider progressSlider;

    public float damageUpCost = 15f;
    public float firerateUpCost = 15f;
    public float arrowSpeedUpCost = 15f;
    void Start()
    {
        progressSlider.maxValue = requiredProgress;
    }
    public void PauseButton()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    public void UpgradeDamage()
    {
        control.damage *= 1.1f;
        points -= damageUpCost;
    }
    public void UpgradeFirerate()
    {
        control.fireRate *= 1.05f;
        points -= firerateUpCost;
    }
    public void UpgradeArrowSpeed()
    {
        control.arrowSpeed *= 1.1f;
        points -= arrowSpeedUpCost;
    }
    public void LoadNextLevel()
    {
        Main.level++;
        SceneManager.LoadScene(Main.level - 1);
    }
    void Update()
    {
        pointsText.text = points.ToString();
        progressSlider.value = points;
        if(points >= requiredProgress)
        {
            NextLevelButton.SetActive(true);
        }
        else
        {
            NextLevelButton.SetActive(false);
        }
    }
}