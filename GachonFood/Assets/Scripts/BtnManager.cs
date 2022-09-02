using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    public Image[] selectBtn;
    public Image[] optionBtn;
    public GameObject[] contents;

    public void Select(int id)
    {
        for(int i = 0; i < contents.Length; i++)
        {
            contents[i].SetActive(false);
            selectBtn[i].color = new Color32(255, 255, 255, 0);
        }
        switch(id)
        {
            case 0:
                contents[0].SetActive(true);
                selectBtn[0].color = new Color32(255, 255, 255, 80);
                break;
            case 1:
                contents[1].SetActive(true);
                selectBtn[1].color = new Color32(255, 255, 255, 80);
                break;
            case 2:
                contents[2].SetActive(true);
                selectBtn[2].color = new Color32(255, 255, 255, 80);
                break;
        }
    }

    public void Option(int id)
    {
        for(int i = 0; i < optionBtn.Length; i++)
        {
            optionBtn[i].color = new Color32(255, 255, 255, 0);
        }
        switch(id)
        {
            case 0:
                optionBtn[0].color = new Color32(255, 255, 255, 80);
                break;
            case 1:
                optionBtn[1].color = new Color32(255, 255, 255, 80);
                break;
        }
    }
}
