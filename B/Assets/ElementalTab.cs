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
        FireDec.text = $"비용 : {gm.ElementalFireDecrease}";
        WaterDec.text = $"비용 : {gm.ElementalWaterDecrease}";
        GrassDec.text = $"비용 : {gm.ElementalGrassDecrease}";
        WindDec.text = $"비용 : {gm.ElementalWindDecrease}";
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
