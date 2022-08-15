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
            FireDec.text = $"��� : {gm.ElementalFireDecrease}";
        if (!gm.ElementalWaterOn)
            WaterDec.text = $"��� : {gm.ElementalWaterDecrease}";
        if (!gm.ElementalGrassOn)
            GrassDec.text = $"��� : {gm.ElementalGrassDecrease}";
        if (!gm.ElementalWindOn)
            WindDec.text = $"��� : {gm.ElementalWindDecrease}";
    }
    void ButtonText()
    {
        if (!gm.ElementalFireOn)
            FireButtonText.text = "����";
        else
            FireButtonText.text = "��ȭ";

        if (!gm.ElementalWaterOn)
            WaterButtonText.text = "����";
        else
            WaterButtonText.text = "��ȭ";

        if (!gm.ElementalGrassOn)
            GrassButtonText.text = "����";
        else
            GrassButtonText.text = "��ȭ";

        if (!gm.ElementalWindOn)
            WindButtonText.text = "����";
        else
            WindButtonText.text = "��ȭ";
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
