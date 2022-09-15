using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    DataBase db;
    BtnManager btnManager;
    public string _name;
    public string _context;
    public List<string> _menuName;
    public List<int> _menuPrice;
    public Sprite _sprite;

    public int id;

    private void Awake()
    {
        db = GameObject.Find("DataBase").GetComponent<DataBase>();
        btnManager = GameObject.Find("BtnManager").GetComponent<BtnManager>();
    }

    private void Start()
    {
        Set();
    }

    public void Set()
    {
        for (int i = 0; i < db.list.food.Length; i++)
        {
            if (id == db.list.food[i].id)
            {
                _name = db.list.food[i].name;
                _context = db.list.food[i].context;
                for(int j = 0; j < db.list.food[i].menu.name.Count; j++)
                {
                    _menuName.Add(db.list.food[i].menu.name[j]);
                    _menuPrice.Add(db.list.food[i].menu.price[j]);
                }
                _sprite = db.list.food[i].sprite;
            }
        }
        transform.GetChild(0).GetComponent<Image>().sprite = _sprite;
        Transform txtPanel = transform.GetChild(1);
        txtPanel.GetChild(0).GetComponent<Text>().text = _name;
        txtPanel.GetChild(1).GetComponent<Text>().text = _context;
        GetComponent<Button>().onClick.AddListener(btnManager.Info);
    }
}
