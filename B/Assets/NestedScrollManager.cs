using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scroll;

    const int SIZE = 5; //��ũ�Ѻ��� ����
    float[] pos = new float[SIZE]; //��ũ�Ѻ��� ������ŭ�� �迭 ����
    float distance, targetPos, curPos; //��ũ�Ѻ��� ����
    bool isDrag;
    int targetIndex;

    // Start is called before the first frame update
    void Start()
    {
        distance = 1f / (SIZE - 1); //��ũ�Ѻ��� ������ 1 / (��ũ�Ѻ� �� -1)
        for (int i = 0; i < SIZE; i++) 
        {
            pos[i] = distance * i; //pos = 1 -> distance�� 1����
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
    }
    // Update is called once per frame
    void Update()
    {

        if (!isDrag) scroll.value = Mathf.Lerp(scroll.value, targetPos, 0.1f);
        
    }
}
