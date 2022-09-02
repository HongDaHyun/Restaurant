using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    CSVReader csvReader;
    Image img;
    Text title;
    Text context;

    public int id;

    private void Awake()
    {
        csvReader = GameObject.Find("CSVReader").GetComponent<CSVReader>();
        img = transform.GetChild(0).GetComponent<Image>();
        Transform txtPanel = transform.GetChild(1);
        title = txtPanel.GetChild(0).GetComponent<Text>();
        context = txtPanel.GetChild(1).GetComponent<Text>();
    }

    private void Start()
    {
        Set();
    }

    void Set()
    {
        for(int i = 0; i < csvReader.list.food.Length; i++)
        {
            if(id == csvReader.list.food[i].id)
            {
                img.sprite = csvReader.list.food[i].sprite;
                title.text = csvReader.list.food[i].name;
                context.text = csvReader.list.food[i].context;
            }
        }
    }
}
