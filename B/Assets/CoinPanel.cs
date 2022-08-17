using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoinPanel : MonoBehaviour, IPointerDownHandler
{
    public GameObject TouchEffect;
    public NestedScrollManager manager;

    public void OnPointerDown(PointerEventData eventData)
    {
        manager.GetCoin();
        if (manager.targetIndex == 0)
        {


            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos += new Vector2(0, 1.5f);
            Instantiate(TouchEffect, pos, Quaternion.identity);

        }
    }
}
