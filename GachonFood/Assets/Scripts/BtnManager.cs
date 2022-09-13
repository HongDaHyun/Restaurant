using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public CSVReader csvReader;
    public NestedScrollManager nested;

    public Image[] selectBtn;
    public GameObject[] contents;
    public GameObject info;

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
        Debug.Log(clickObj.name);
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

    void DoubleClick()
    {
        clickCount = 0;
    }

    public void OnlineChat()
    {
        SceneManager.LoadScene(1);
    }
}
