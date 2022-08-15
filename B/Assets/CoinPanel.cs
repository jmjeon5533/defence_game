using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoinPanel : MonoBehaviour, IPointerDownHandler
{

    public NestedScrollManager manager;

    public void OnPointerDown(PointerEventData eventData)
    {
        
        manager.GetCoin();
    }
}
