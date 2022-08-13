using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scroll;

    public Slider tabSlider;
    public RectTransform[] BtnRect; 

    GameManager gm;

    const int SIZE = 5; //스크롤뷰의 갯수
    float[] pos = new float[SIZE]; //스크롤뷰의 갯수만큼의 배열 생성
    float distance, targetPos, curPos; //스크롤뷰의 간격
    bool isDrag;
    int targetIndex;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        distance = 1f / (SIZE - 1); //스크롤뷰의 간격은 1 / (스크롤뷰 수 -1)
        for (int i = 0; i < SIZE; i++)
        {
            pos[i] = distance * i; //pos = 1 -> distance의 1개값
        }
    }
    float SetPos()
    {
        for (int i = 0; i < SIZE; i++)
            if (scroll.value < pos[i] + distance * 0.5f &&
                scroll.value > pos[i] - distance * 0.5f)
            {
                targetIndex = i;
                return pos[i];
            }
        return 0;
    }
    public void OnBeginDrag(PointerEventData eventData) => curPos = SetPos();

    public void OnDrag(PointerEventData eventData) => isDrag = true;

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;

        targetPos = SetPos();

        if (curPos == targetPos)
        {
            if (eventData.delta.x > 18 && curPos - distance >= 0)
            {
                --targetIndex;
                targetPos = curPos - distance;
            }
            else if (eventData.delta.x < -18 && curPos + distance <= 1.01f)
            {
                ++targetIndex;
                targetPos = curPos + distance;
            }
        }
/*
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                if (contentTr.GetChild(i).GetChild(j).GetComponent<ScrollScript>() && curPos != pos[i] && targetPos == pos[i])
                {
                    contentTr.GetChild(i).GetChild(0).GetComponent<Scrollbar>().value = 1;
                }
            }
        }
*/
    }
    // Update is called once per frame
    void Update()
    {
        tabSlider.value = scroll.value;
        
        if (!isDrag) scroll.value = Mathf.Lerp(scroll.value, targetPos, 0.1f);

        //for (int i = 0; i < SIZE; i++) BtnRect[i].sizeDelta = new Vector2(i == targetIndex ? 480 : 240, BtnRect[i].sizeDelta.y);
        
    }

    public void GetCoin()
    {
        GameManager.Money += gm.TouchMoney;
    }

    public void TabClick(int n)
    {
        targetIndex = n;
        targetPos = pos[n];
    }

}
