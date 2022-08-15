using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementalTab : MonoBehaviour
{
    GameManager gm;
    public Text FireDec, WaterDec, GrassDec, WindDec;

    public Text FireButtonText, WaterButtonText, GrassButtonText, WindButtonText;

    void Start()
    {
        gm = GetComponent<GameManager>();
    }
    
    void Update()
    {
        Decrease();
        ButtonText();
    }
    void Decrease()
    {
        if (!gm.ElementalFireOn)
            FireDec.text = $"비용 : {gm.ElementalFireDecrease}";
        if (!gm.ElementalWaterOn)
            WaterDec.text = $"비용 : {gm.ElementalWaterDecrease}";
        if (!gm.ElementalGrassOn)
            GrassDec.text = $"비용 : {gm.ElementalGrassDecrease}";
        if (!gm.ElementalWindOn)
            WindDec.text = $"비용 : {gm.ElementalWindDecrease}";
    }
    void ButtonText()
    {
        if (!gm.ElementalFireOn)
            FireButtonText.text = "영입";
        else
            FireButtonText.text = "강화";

        if (!gm.ElementalWaterOn)
            WaterButtonText.text = "영입";
        else
            WaterButtonText.text = "강화";

        if (!gm.ElementalGrassOn)
            GrassButtonText.text = "영입";
        else
            GrassButtonText.text = "강화";

        if (!gm.ElementalWindOn)
            WindButtonText.text = "영입";
        else
            WindButtonText.text = "강화";
    }
    public void FireButton()
    {
        if (!gm.ElementalFireOn)
        {
            if (GameManager.Money >= gm.ElementalFireDecrease)
            {
                gm.ElementalFireOn = true;
                GameManager.Money -= gm.ElementalFireDecrease;

            }
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
