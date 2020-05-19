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
    public static List<GameObject> Mushrooms = new List<GameObject>();
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
        save.SaveMushroms(Mushrooms);

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
        save.LoadMushrooms(Mushrooms);
        Debug.Log($"Loading money: {save.scoremoney}");

        gameData.GeneralPoints = save.scoremoney;

        fs.Close();
    }
    [System.Serializable]
    public class Save
    {
        public int scoremoney;
        [System.Serializable]
        public struct Vect3
        {
            public float x, y, z;
            public Vect3(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
        [System.Serializable]
        public struct MushroomSavePos
        {
            public Vect3 Position;
            public MushroomSavePos(Vect3 pos)
            {
                Position = pos;
            }
        }
        public List<MushroomSavePos> SavedMushrooms = new List<MushroomSavePos>();
        public void SaveMushroms(List<GameObject> mushrooms)
        {
            foreach (var mushroom in mushrooms)
            {
                Vect3 pos = new Vect3(mushroom.transform.position.x, mushroom.transform.position.y, mushroom.transform.position.z);
                SavedMushrooms.Add(new MushroomSavePos(pos));
            }
        }
        public void LoadMushrooms(List<GameObject> mushrooms)
        {
            if (SavedMushrooms.Capacity > mushrooms.Capacity)
            {
                foreach (var mushroom in mushrooms)
                {
                    foreach (var savedPos in SavedMushrooms)
                    {
                        mushroom.transform.position = new Vector3(savedPos.Position.x, savedPos.Position.y, savedPos.Position.z);
                        SavedMushrooms.Remove(savedPos);
                        break;
                    }
                }
            }
        }

    }
}

