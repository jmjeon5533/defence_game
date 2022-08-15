using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementalTab : MonoBehaviour
{
    GameManager gm;
    public 

    void Start()
    {
        gm = GetComponent<GameManager>();
    }

    
    void Update()
    {
        
    }
    public void FireButton()
    {
        if (GameManager.Money >= gm.ElementalFireDecrease)
        {
            GameManager.Money -= gm.ElementalFireDecrease;
        }
    }
    public void WaterButton()
    {
        if (GameManager.Money >= gm.ElementalWaterDecrease)
        {
            GameManager.Money -= gm.ElementalWaterDecrease;
        }
    }
    public void GrassButton()
    {
        if (GameManager.Money >= gm.ElementalGrassDecrease)
        {
            GameManager.Money -= gm.ElementalGrassDecrease;
        }
    }
    public void WindButton()
    {
        if (GameManager.Money >= gm.ElementalWindDecrease)
        {
            GameManager.Money -= gm.ElementalWindDecrease;
        }
    }
}
