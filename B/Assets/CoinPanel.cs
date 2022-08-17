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
        if (manager.targetIndex == 0)
        {
            manager.GetCoin();
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos += new Vector2(0, 0.3f);
            Instantiate(TouchEffect, pos, Quaternion.identity);
        }
    }
}
