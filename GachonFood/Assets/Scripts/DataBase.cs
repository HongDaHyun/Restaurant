using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataBase : MonoBehaviour
{
    [Serializable]
    public class Food
    {
        public string name;
        public string context;
        public Menu menu;
        public int id;
        public Sprite sprite;
    }

    [Serializable]
    public class Cafe
    {
        public string name;
        public string context;
        public Menu menu;
        public int id;
        public Sprite sprite;
    }

    [Serializable]
    public class Exercise
    {
        public string name;
        public string context;
        public Menu menu;
        public int id;
        public Sprite sprite;
    }

    [Serializable]
    public class Menu
    {
        public List<string> name;
        public List<int> price;
    }

    [Serializable]
    public class List
    {
        public Food[] food;
        public Cafe[] cafe;
        public Exercise[] exercise;
    }

    public List list = new List();

    [ContextMenu("Json파일로 저장")]
    void SaveDataToJson()
    {
        string jsonData = JsonUtility.ToJson(list, true);
        string path = Path.Combine(Application.dataPath + "/Scripts/", "data.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("Json파일 불러오기")]
    void LoadDataToJson()
    {
        string path = Path.Combine(Application.dataPath + "/Scripts/", "data.json");
        string jsonData = File.ReadAllText(path);
        list = JsonUtility.FromJson<List>(jsonData);
    }
}
