using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataBase : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] parentTransPrefabs;

    [Serializable]
    public class Food
    {
        public string name;
        public string context;
        public string url;
        public List<string> combination;
        public Menu menu;
        public Sprite sprite;
    }

    [Serializable]
    public class Cafe
    {
        public string name;
        public string context;
        public string url;
        public List<string> combination;
        public Menu menu;
        public Sprite sprite;
    }

    [Serializable]
    public class Exercise
    {
        public string name;
        public string context;
        public string url;
        public List<string> combination;
        public Menu menu;
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

    private void Start()
    {
        for (int i = 0; i < list.food.Length; i++)
        {
            GameObject gameObject = Instantiate(prefabs[0]);
            gameObject.transform.SetParent(parentTransPrefabs[0], false);
            gameObject.name = list.food[i].name;
        }
        for (int i = 0; i < list.cafe.Length; i++)
        {
            GameObject gameObject = Instantiate(prefabs[1]);
            gameObject.transform.SetParent(parentTransPrefabs[1], false);
            gameObject.name = list.cafe[i].name;
        }
        //for (int i = 0; i < list.exercise.Length; i++)
        //{
        //    GameObject gameObject = Instantiate(prefabs[2]);
        //    gameObject.transform.SetParent(parentTransPrefabs[2], false);
        //    gameObject.name = list.exercise[i].name;
        //}
    }

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
