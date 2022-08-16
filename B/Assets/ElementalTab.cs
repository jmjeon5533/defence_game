using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementalTab : MonoBehaviour
{
    GameManager gm;
    public Text FireDec, WaterDec, GrassDec, WindDec;

    public Text FireButtonText, WaterButtonText, GrassButtonText, WindButtonText;

    public Text FirePerSecond, WaterPerSecond, GrassPerSecond, WindPerSecond;

    public GameObject Fire, Water, Grass, Wind;

    public Text FireNum, WaterNum, GrassNum, WindNum;

    Vector2 vec;

    void Start()
    {
        gm = GetComponent<GameManager>();
        
    }

    void Update()
    {
        Decrease();
        vec = new Vector2(Random.Range(-1.85f, 1.85f), Random.Range(-1.85f, 1.85f));
    }
    void Decrease() //��ȭ ���
    {
        FireDec.text = $"��� :\n{gm.ElementalFireUpgradeDecrease[gm.ElementalFireLevel]}";
        WaterDec.text = $"��� :\n{gm.ElementalWaterUpgradeDecrease[gm.ElementalWaterLevel]}";
        GrassDec.text = $"��� :\n{gm.ElementalGrassUpgradeDecrease[gm.ElementalGrassLevel]}";
        WindDec.text = $"��� :\n{gm.ElementalWindUpgradeDecrease[gm.ElementalWindLevel]}";

        FirePerSecond.text = $"+���� ��\n��ȭ ���� +{gm.ElementalFireMoney[gm.ElementalFireMoneyLevel]}";
        WaterPerSecond.text = $"�ʴ�\n��ȭ ���� +{gm.ElementalWaterMoney[gm.ElementalWaterMoneyLevel]}";
        GrassPerSecond.text = $"���� ���Ѽ� �߰� +{gm.ElementalGrassMoney}";
        WindPerSecond.text = $"�ǹ� ����\n���ð� ���� +{gm.ElementalWindMoney}";

        FireNum.text = $"+{gm.ElementalFireNumber}";
        WaterNum.text = $"+{gm.ElementalWaterNumber}";
        GrassNum.text = $"+{gm.ElementalGrassNumber}";
        WindNum.text = $"{gm.ElementalWindNumber}";
    }
    public void FireButton()
    {
        if (!gm.ElementalMaximum)
        {
            if (GameManager.Money >=
                gm.ElementalFireUpgradeDecrease[gm.ElementalFireLevel])
            {

                GameManager.Money -= gm.ElementalFireUpgradeDecrease[gm.ElementalFireLevel];
                gm.ElementalFireLevel++;
                gm.ElementalFireOn = true;
                Instantiate(Fire, vec, Quaternion.identity);
                gm.ElementalFireMoneyLevel++;
                gm.ElementalFireNumber++;
            }
        }
        else
        {
            gm.ElementalError();
        }
    }
    public void WaterButton()
    {
        if (!gm.ElementalMaximum)
        {
            if (GameManager.Money >=
            gm.ElementalWaterUpgradeDecrease[gm.ElementalWaterLevel])
            {

                GameManager.Money -= gm.ElementalWaterUpgradeDecrease[gm.ElementalWaterLevel];
                gm.ElementalWaterLevel++;
                gm.ElementalWaterOn = true;
                Instantiate(Water, vec, Quaternion.identity);
                gm.ElementalWaterMoneyLevel++;
                gm.ElementalWaterNumber++;
            }
        }
        else
        {
            gm.ElementalError();
        }
    }
    public void GrassButton()
    {
        if (!gm.ElementalMaximum)
        {
            if (GameManager.Money >=
            gm.ElementalGrassUpgradeDecrease[gm.ElementalGrassLevel])
            {

                GameManager.Money -= gm.ElementalFireUpgradeDecrease[gm.ElementalGrassLevel];
                gm.ElementalGrassLevel++;
                gm.ElementalGrassOn = true;
                Instantiate(Grass, vec, Quaternion.identity);
                gm.ElementalGrassMoneyLevel++;
                gm.ElementalGrassNumber++;
            }
        }
        else
        {
            gm.ElementalError();
        }
    }
    public void WindButton()
    {
        if (!gm.ElementalMaximum)
        {
            if (GameManager.Money >=
            gm.ElementalWindUpgradeDecrease[gm.ElementalFireLevel])
            {

                GameManager.Money -= gm.ElementalWindUpgradeDecrease[gm.ElementalWindLevel];
                gm.ElementalWindLevel++;
                gm.ElementalWindOn = true;
                Instantiate(Wind, vec, Quaternion.identity);
                gm.ElementalWindMoneyLevel++;
                gm.ElementalWindNumber++;
            }
        }
        else
        {
            gm.ElementalError();
        }
    }
}
