using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Silder slider;
    friendly friend;
    Enemy Enem;
    public int supplyMoneySpeed = 2;
    public int supplyMoneyDecrease = 55;


    public static int count;

    public GameObject friendly;
    public GameObject Enemy;

    #region ¼Ò¸ð°ª
    public int firstbuttonDecrease = 10;
    public int secondbuttonDecrease = 25;
    public int thirdbuttonDecrease = 50;
    public int fourthbuttonDecrease = 75;
    public int fifthbuttonDecrease = 100;

    #endregion

    void Start()
    {
        slider = GameObject.Find("MoneySlider").GetComponent<Silder>();
        friend = GetComponent<friendly>();
        Enem = GetComponent<Enemy>();
        StartCoroutine(Money());
        StartCoroutine(Count());
    }

    
    void Update()
    {
        
    }
    
    IEnumerator Money()
    {
        slider.slMoney.value += supplyMoneySpeed;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Money());
    }
    public void supplySpeed()
    {
        if (slider.slMoney.value >= supplyMoneyDecrease)
        {
            slider.slMoney.value -= supplyMoneyDecrease;
            supplyMoneyDecrease += 30;
            supplyMoneySpeed += 3;
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
    public void fourthbutton()
    {
        if (slider.slMoney.value >= fourthbuttonDecrease)
        {
            slider.slMoney.value -= fourthbuttonDecrease;
        }
    }
    public void fifthbutton()
    {
        if(slider.slMoney.value >= fifthbuttonDecrease)
        {
            slider.slMoney.value -= fifthbuttonDecrease;
        }
    }
    IEnumerator Count()
    {
        yield return new WaitForSecondsRealtime(1);
        count++;
    }
    public void SummonButton()
    {

    }
}
