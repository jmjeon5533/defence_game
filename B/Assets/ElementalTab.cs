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

    Vector2 vec;

    void Start()
    {
        gm = GetComponent<GameManager>();
        
    }

    void Update()
    {
        Decrease();
        vec = new Vector2(Random.Range(-11.35f, -9.85f), Random.Range(-1.2f, 0.3f));
    }
    void Decrease() //강화 비용
    {
        FireDec.text = $"비용 :\n{gm.ElementalFireUpgradeDecrease[gm.ElementalFireLevel]}";
        WaterDec.text = $"비용 :\n{gm.ElementalWaterUpgradeDecrease[gm.ElementalWaterLevel]}";
        GrassDec.text = $"비용 :\n{gm.ElementalGrassUpgradeDecrease[gm.ElementalGrassLevel]}";
        WindDec.text = $"비용 :\n{gm.ElementalWindUpgradeDecrease[gm.ElementalWindLevel]}";

        FirePerSecond.text = $"+터지 당\n재화 수급 : {gm.ElementalFireMoney[gm.ElementalFireMoneyLevel]}";
        WaterPerSecond.text = $"초당\n재화 수급 : {gm.ElementalWaterMoney[gm.ElementalWaterMoneyLevel]}";
        GrassPerSecond.text = $"원소 상한선 추가 : {gm.ElementalGrassMoney}";
        WindPerSecond.text = $"피버 재사용\n대기시간 감소 : {gm.ElementalWindMoney}";
    }
    public void FireButton()
    {
        if(GameManager.Money >=
            gm.ElementalFireUpgradeDecrease[gm.ElementalFireLevel])
        {
            
            GameManager.Money -= gm.ElementalFireUpgradeDecrease[gm.ElementalFireLevel];
            gm.ElementalFireLevel++;
            gm.ElementalFireOn = true;
            Instantiate(Fire,vec,Quaternion.identity);
            gm.ElementalFireMoneyLevel++;
        }
    }
    public void WaterButton()
    {
        if (GameManager.Money >=
            gm.ElementalWaterUpgradeDecrease[gm.ElementalWaterLevel])
        {

            GameManager.Money -= gm.ElementalWaterUpgradeDecrease[gm.ElementalWaterLevel];
            gm.ElementalWaterLevel++;
            gm.ElementalWaterOn = true;
            gm.ElementalWaterMoneyLevel++;
        }
    }
    public void GrassButton()
    {
        if (GameManager.Money >=
            gm.ElementalGrassUpgradeDecrease[gm.ElementalGrassLevel])
        {

            GameManager.Money -= gm.ElementalFireUpgradeDecrease[gm.ElementalGrassLevel];
            gm.ElementalGrassLevel++;
            gm.ElementalGrassOn = true;
            gm.ElementalGrassMoneyLevel++;
        }
    }
    public void WindButton()
    {
        if (GameManager.Money >=
            gm.ElementalWindUpgradeDecrease[gm.ElementalFireLevel])
        {

            GameManager.Money -= gm.ElementalWindUpgradeDecrease[gm.ElementalWindLevel];
            gm.ElementalWindLevel++;
            gm.ElementalWindOn = true;
            gm.ElementalWindMoneyLevel++;
        }
    }
}
