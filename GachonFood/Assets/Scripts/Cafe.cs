using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cafe : MonoBehaviour
{
    DataBase db;
    BtnManager btnManager;
    public string _name;
    public string _context;
    public string _url;
    public List<string> _combination;
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
        for (int i = 0; i < db.list.cafe.Length; i++)
        {
            if (name == db.list.cafe[i].name)
            {
                _name = db.list.cafe[i].name;
                _context = db.list.cafe[i].context;
                _url = db.list.cafe[i].url;
                _combination = db.list.cafe[i].combination;
                _menuName = db.list.cafe[i].menu.name;
                _menuPrice = db.list.cafe[i].menu.price;
                _sprite = db.list.cafe[i].sprite;
            }
        }
        transform.GetChild(0).GetComponent<Image>().sprite = _sprite;
        Transform txtPanel = transform.GetChild(1);
        txtPanel.GetChild(0).GetComponent<Text>().text = _name;
        txtPanel.GetChild(1).GetComponent<Text>().text = _context;
        GetComponent<Button>().onClick.AddListener(btnManager.Info);
    }
}
