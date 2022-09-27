using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public DataBase db;
    public NestedScrollManager nested;

    public Image[] selectBtn;
    public GameObject[] contents;

    public GameObject info;
    public Scrollbar infoScroll;
    public Image infoImg;
    public Text infoTitle;
    public Text infoContents;
    public Text[] menuName;
    public Text[] menuPrice;
    public Text combinationTxt;

    string curUrl;
    Animator infoAnim;

    int clickCount = 0;

    private void Awake()
    {
        infoAnim = info.GetComponent<Animator>();
    }

    private void Update()
    {
        EscapeBtn();
    }

    public void Select(int id)
    {
        for(int i = 0; i < contents.Length; i++)
        {
            selectBtn[i].color = new Color32(255, 255, 255, 0);
        }
        nested.targetIndex = id;
        nested.targetPos = nested.pos[id];
        nested.scrollbar.value = Mathf.Lerp(nested.scrollbar.value, nested.targetPos, 0.3f);
        contents[id].GetComponentInParent<ScrollScript>().content = contents[id].GetComponent<RectTransform>();
        selectBtn[id].color = new Color32(255, 255, 255, 80);
    }

    public void Info()
    {
        GameObject clickObj = EventSystem.current.currentSelectedGameObject;
        Food f = clickObj.GetComponent<Food>();
        Cafe c = clickObj.GetComponent<Cafe>();
        Exercise e = clickObj.GetComponent<Exercise>();
        string combination = null;
        if(f != null)
        {
            infoImg.sprite = f._sprite;
            infoTitle.text = f._name;
            infoContents.text = f._context;
            curUrl = f._url;
            for(int i = 0; i < f._menuName.Count; i++)
            {
                menuName[i].text = f._menuName[i];
                menuPrice[i].text = (f._menuPrice[i] / 1000).ToString() + ",000¿ø";
            }
            for(int i = 0; i < f._combination.Count; i++)
            {
                combination += f._combination[i];
                if (i != f._combination.Count - 1)
                    combination += ", ";
            }
            if (combination == null)
                combinationTxt.text = "Á¦ÈÞ X";
            else
                combinationTxt.text = combination;

        }
        else if(c != null)
        {
            infoImg.sprite = c._sprite;
            infoTitle.text = c._name;
            infoContents.text = c._context;
            curUrl = c._url;
            for (int i = 0; i < c._menuName.Count; i++)
            {
                menuName[i].text = c._menuName[i];
                menuPrice[i].text = (c._menuPrice[i] / 1000).ToString() + ",000¿ø";
            }
            for (int i = 0; i < c._combination.Count; i++)
            {
                combination += c._combination[i];
                if (i != c._combination.Count - 1)
                    combination += ", ";
            }
            if (combination == null)
                combinationTxt.text = "Á¦ÈÞ X";
        }
        else if(e != null)
        {
            //infoImg.sprite = e._sprite;
            //infoTitle.text = e._name;
            //infoContents.text = e._context;
            //curUrl = e._url;
            //for (int i = 0; i < e._menuName.Count; i++)
            //{
            //    menuName[i].text = e._menuName[i];
            //    menuPrice[i].text = (e._menuPrice[i] / 1000).ToString() + ",000¿ø";
            //}
            //for (int i = 0; i < e._combination.Count; i++)
            //{
            //    combination += e._combination[i];
            //    if (i != e._combination.Count - 1)
            //        combination += ", ";
            //}
            //if (combination == null)
            //    combinationTxt.text = "Á¦ÈÞ X";
        }
        infoScroll.value = 1;
        infoAnim.SetBool("IsShow", true);
    }

    public void EscapeBtn()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (infoAnim.GetBool("IsShow"))
            {
                infoAnim.SetBool("IsShow", false);
                return;
            }
            else
            {
                clickCount++;
                if (!IsInvoking("DoubleClick"))
                    Invoke("DoubleClick", 1.0f);
            }
            Debug.Log(clickCount);
        }
        else if(clickCount == 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }
    }

    public void WebViewBtn()
    {
        Application.OpenURL(curUrl);
    }

    void DoubleClick()
    {
        clickCount = 0;
    }

    public void OnlineChat()
    {
        SceneManager.LoadScene(1);
    }
}
