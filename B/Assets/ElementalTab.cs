using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementalTab : MonoBehaviour
{
    public static ElementalTab elemetal = new ElementalTab();
    private ElementalTab() { }

    public static ElementalTab getInstance()
    {
        return elemetal;
    }
    GameManager gm;
    public Text FireDec, WaterDec, GrassDec, WindDec;

    public Text FirePerSecond, WaterPerSecond, GrassPerSecond, WindPerSecond;

    public GameObject Fire, Water, Grass, Wind;

    public Text FireNum, WaterNum, GrassNum, WindNum;

    Vector2 vec;

    public GameObject Firebutton, Waterbutton, Grassbutton, Windbutton;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    void Update()
    {
        Decrease();
        vec = new Vector2(Random.Range(-1.9f, 1.9f), Random.Range(-1.85f, 1.85f));
    }
    void Decrease() //강화 비용
    {
        FireDec.text = string.Format("비용 :\n{0:N0}",gm.ElementalFireUpgradeDecrease);
        WaterDec.text = string.Format("비용 :\n{0:N0}", gm.ElementalWaterUpgradeDecrease);
        GrassDec.text = string.Format("비용 :\n{0:N0}", gm.ElementalGrassUpgradeDecrease);
        WindDec.text = string.Format("비용 :\n{0:N0}", gm.ElementalWindUpgradeDecrease);

        FirePerSecond.text = string.Format("+터치 당\n재화 수급 +{0:N0}", gm.ElementalFireMoney);
        WaterPerSecond.text = string.Format("초당\n재화 수급 +{0:N0}", gm.ElementalWaterMoney);
        GrassPerSecond.text = $"원소 상한선 추가 +{gm.ElementalGrassMoney}";
        WindPerSecond.text = $"피버 재사용\n대기시간 감소 +{Mathf.Round(gm.ElementalWindMoney * 100)}%";

        FireNum.text = $"+{gm.ElementalFireNumber}";
        WaterNum.text = $"+{gm.ElementalWaterNumber}";
        GrassNum.text = $"+{gm.ElementalGrassNumber}";
        WindNum.text = $"+{gm.ElementalWindNumber}";
    }
    public void FireButton()
    {
        if (!gm.ElementalMaximum)
        {
            if (GameManager.Money >=
                gm.ElementalFireUpgradeDecrease)
            {

                GameManager.Money -= (uint)gm.ElementalFireUpgradeDecrease;
                gm.ElementalFireLevel++;
                gm.ElementalFireOn = true;
                Instantiate(Fire, vec, Quaternion.identity);
                gm.ElementalFireMoneyLevel++;
                gm.ElementalFireNumber++;
                gm.ElementalFireMoney += 200;
                if (gm.ElementalFireMoneyLevel == 20)
                {
                    Firebutton.SetActive(false);
                }
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
            gm.ElementalWaterUpgradeDecrease)
            {

                GameManager.Money -= (uint)gm.ElementalWaterUpgradeDecrease;
                gm.ElementalWaterLevel++;
                gm.ElementalWaterOn = true;
                Instantiate(Water, vec, Quaternion.identity);
                gm.ElementalWaterMoneyLevel++;
                gm.ElementalWaterNumber++;
                gm.ElementalWaterMoney += 200;
                if (gm.ElementalWaterMoneyLevel == 20)
                {
                    Waterbutton.SetActive(false);
                    gm.ElementalWaterMoneyLevel++;
                }
            }
        }
        else
        {
            gm.ElementalError();
        }
    }
    public void GrassButton()
    {
        if (GameManager.Money >=
        gm.ElementalGrassUpgradeDecrease)
        {

            GameManager.Money -= (uint)gm.ElementalGrassUpgradeDecrease;
            gm.ElementalGrassLevel++;
            gm.ElementalGrassOn = true;
            Instantiate(Grass, vec, Quaternion.identity);
            gm.ElementalGrassMoney++;
            gm.ElementalGrassMoneyLevel++;
            gm.ElementalMaxNum += 1;
            if (gm.ElementalGrassMoneyLevel == 10)
            {
                Grassbutton.SetActive(false);
                gm.ElementalGrassMoneyLevel++;
            }
        }
    }
    public void WindButton()
    {
        if (!gm.ElementalMaximum)
        {
            if (GameManager.Money >=
            gm.ElementalWindUpgradeDecrease)
            {

                GameManager.Money -= (uint)gm.ElementalWindUpgradeDecrease;
                gm.ElementalWindLevel++;
                gm.ElementalWindOn = true;
                Instantiate(Wind, vec, Quaternion.identity);
                gm.ElementalWindMoneyLevel++;
                gm.ElementalWindNumber++;
                gm.ElementalWindMoney += 0.04f;
                if(gm.ElementalWindMoneyLevel == 10)
                {
                    Windbutton.SetActive(false);
                }
            }
        }
        else
        {
            gm.ElementalError();
        }
    }
}
