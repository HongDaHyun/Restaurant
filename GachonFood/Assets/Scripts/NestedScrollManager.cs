using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public BtnManager btnManager;
    public Scrollbar scrollbar;

    const int SIZE = 3;
    public float[] pos = new float[SIZE];
    float distance, curPos;
    public float targetPos;
    bool isDrag;
    public int targetIndex;

    private void Start()
    {
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;
    }

    private void Update()
    {
        if(!isDrag)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.3f);

            for(int i = 0; i < btnManager.selectBtn.Length; i++)
                btnManager.selectBtn[i].color = new Color32(255, 255, 255, 0);
            switch(targetIndex)
            {
                case 0:
                    btnManager.selectBtn[0].color = new Color32(255, 255, 255, 80);
                    break;
                case 1:
                    btnManager.selectBtn[1].color = new Color32(255, 255, 255, 80);
                    break;
                case 2:
                    btnManager.selectBtn[2].color = new Color32(255, 255, 255, 80);
                    break;
            }
                
        }
    }

    public void OnBeginDrag(PointerEventData eventData) => curPos = SetPos();

    public void OnDrag(PointerEventData eventData) => isDrag = true;

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        targetPos = SetPos();

        if(curPos == targetPos)
        {
            if(eventData.delta.x > 18 && curPos - distance >= 0)
            {
                --targetIndex;
                targetPos = curPos - distance;
            }
            else if(eventData.delta.x < -18 && curPos + distance <= 1.01f)
            {
                ++targetIndex;
                targetPos = curPos + distance;
            }
        }
    }

    float SetPos()
    {
        for (int i = 0; i < SIZE; i++)
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetIndex = i;
                return pos[i];
            }
        return 0;
    }
}
