using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveLoad : MonoBehaviour
{
    private string filePath;
    private Transform _player;
    private Transform _collector;
    private void Start()
    {
        filePath = Application.persistentDataPath + "/save.idlesave";
        Debug.Log(filePath);
        _player = GameObject.FindGameObjectWithTag("mushroom").transform;
        _collector = GameObject.FindGameObjectWithTag("collector").transform;
    }
    public void SaveGame()
    {
        BinaryFormatter bm = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);
        Save save = new Save();

        save.plX = _player.position.x;
        save.plY = _player.position.y;
        save.plZ = _player.position.z;

        save.scoremoney = gameData.GeneralPoints;

        Debug.Log($"Saving money: {save.scoremoney}");
        bm.Serialize(fs, save);
        fs.Close();

    }
    public void LoadGame()
    {
        if (!File.Exists(filePath)) return;
        BinaryFormatter bm = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);
        Save save = (Save)bm.Deserialize(fs);
        Debug.Log($"Loading money: {save.scoremoney}");

        gameData.GeneralPoints = save.scoremoney;

        _player.position = new Vector3(save.plX, save.plY, save.plZ);

        fs.Close();
    }
    [System.Serializable]
    public class Save
    {
        public int scoremoney;

        public float plX;
        public float plY;
        public float plZ;

        public float coX;
        public float coY;
        public float coZ;
    }
}

