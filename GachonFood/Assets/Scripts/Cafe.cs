using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cafe : MonoBehaviour
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
        for (int i = 0; i < csvReader.list.cafe.Length; i++)
        {
            if (id == csvReader.list.cafe[i].id)
            {
                img.sprite = csvReader.list.cafe[i].sprite;
                title.text = csvReader.list.cafe[i].name;
                context.text = csvReader.list.cafe[i].context;
            }
        }
    }
}
