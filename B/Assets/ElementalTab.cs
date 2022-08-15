using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementalTab : MonoBehaviour
{
    GameManager gm;
    public Text FireDec, WaterDec, GrassDec, WindDec;
    public bool FireOn = false, WaterOn = false, GrassOn = false, WindOn = false;

    void Start()
    {
        gm = GetComponent<GameManager>();
    }
    
    void Update()
    {
        Decrease();
    }
    void Decrease()
    {
        FireDec.text = $"��� : {gm.ElementalFireDecrease}";
        WaterDec.text = $"��� : {gm.ElementalWaterDecrease}";
        GrassDec.text = $"��� : {gm.ElementalGrassDecrease}";
        WindDec.text = $"��� : {gm.ElementalWindDecrease}";
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
