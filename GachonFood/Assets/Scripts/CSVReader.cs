using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset[] textAssets;

    [Serializable]
    public class Food
    {
        public string name;
        public string context;
        public int id;
        public GameObject marker;
        public Sprite sprite;
    }

    [Serializable]
    public class Cafe
    {
        public string name;
        public string context;
        public int id;
        public GameObject marker;
        public Sprite sprite;
    }

    [Serializable]
    public class Exercise
    {
        public string name;
        public string context;
        public int id;
        public GameObject marker;
        public Sprite sprite;
    }

    [Serializable]
    public class List
    {
        public Food[] food;
        public Cafe[] cafe;
        public Exercise[] exercise;
    }

    public List list = new List();

    [ContextMenu("맛집 가져오기")]
    void FoodCSV()
    {
        string[] data = textAssets[0].text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int tableSize = data.Length / 3 - 1;
        list.food = new Food[tableSize];

        for(int i = 0; i < tableSize; i++)
        {
            list.food[i] = new Food();
            list.food[i].name = data[3 * (i + 1)];
            list.food[i].context = data[3 * (i + 1) + 1];
            list.food[i].id = int.Parse(data[3 * (i + 1) + 2]);
        }
    }

    [ContextMenu("카페 가져오기")]
    void CafeCSV()
    {
        string[] data = textAssets[1].text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int tableSize = data.Length / 3 - 1;
        list.cafe = new Cafe[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            list.cafe[i] = new Cafe();
            list.cafe[i].name = data[3 * (i + 1)];
            list.cafe[i].context = data[3 * (i + 1) + 1];
            list.cafe[i].id = int.Parse(data[3 * (i + 1) + 2]);
        }
    }
}
