using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Silder slider;
    public int supplyMoneySpeed = 5;
    public int supplyMoneyDecrease = 55;

    #region ¼Ò¸ð°ª
    public int firstbuttonDecrease = 10;
    public int secondbuttonDecrease = 25;
    public int thirdbuttonDecrease = 50;
    #endregion

    void Start()
    {
        slider = GameObject.Find("MoneySlider").GetComponent<Silder>();
        StartCoroutine(Money());
    }

    
    void Update()
    {
        
    }
    
    IEnumerator Money()
    {
        slider.slMoney.value += supplyMoneySpeed;
        yield return new WaitForSeconds(1);
        StartCoroutine(Money());
    }
    public void supplySpeed()
    {
        if (slider.slMoney.value >= supplyMoneyDecrease)
        {
            slider.slMoney.value -= supplyMoneyDecrease;
            supplyMoneyDecrease += 20;
            supplyMoneySpeed += 7;
        }
    }
    public void firstbutton()
    {
        if (slider.slMoney.value >= firstbuttonDecrease)
        {
            slider.slMoney.value -= firstbuttonDecrease;
        }

    }
    public void secondbutton()
    {
        if (slider.slMoney.value >= secondbuttonDecrease)
        {
            slider.slMoney.value -= secondbuttonDecrease;
        }
    }
    public void thirdbutton()
    {
        if (slider.slMoney.value >= thirdbuttonDecrease)
        {
            slider.slMoney.value -= thirdbuttonDecrease;
        }
    }
}
