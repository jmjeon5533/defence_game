using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Silder slider;
    public float supplySpeed = 1f;

    public static float Money = 0;

    public Text TouchMoneyUp;
    public Text TouchMoneyDec;
    public int TouchMoney = 1;
    public int TouchMoneyLevel = 1;
    public float TouchMoneyDecrease = 10;

    public Text perSecondMoneyUp;
    public Text PerSecondMoneyDec;
    public int PerSecondMoney = 0;
    public int PerSecondMoneyLevel = 0;
    public float PerSecondMoneyDecrease = 100;

    public Text FeverDec;
    public int FeverDecrease = 5000;

    public Text MoneyText;
    public Text TouchResource;
    public Text PerSecondResource;

    public static int count;

    public GameObject Maximum;

    public GameObject FillColor;

    public GameObject fever;
    public int tabfever = 1;
    public int perfever = 0;
    public GameObject feverSetButton;

    public bool FeverOn = false;
    void Start()
    {
        slider = GameObject.Find("ExperienceSlider").GetComponent<Silder>();

        fever.SetActive(false);
        Maximum.SetActive(false);
        StartCoroutine(PerMoneyCount());
        FeverDec.text = $"비용 : {FeverDecrease}";
    }


    void Update()
    {
        //FeverMoney();
        Cheat();
        MoneyUI();
    }
   /*
    void FeverMoney()
    {
        if (FeverOn)
        {
            tabfever = TouchMoney;
            TouchMoney = TouchMoney * 2;

            perfever = PerSecondMoney;
            PerSecondMoney = PerSecondMoney * 2;
        }
    }
   */
    void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Money += 1000;
        }
    }
    void MoneyUI()
    {
        MoneyText.text = Money.ToString();
        TouchResource.text = $"터치 당 재화 : {TouchMoney}";
        PerSecondResource.text = $"초 당 재화 : {PerSecondMoney}";

        TouchMoneyUp.text = $"터치 당 재화 \n수급량 + {TouchMoney}";
        TouchMoneyDec.text = $"비용 : {TouchMoneyDecrease}";

        perSecondMoneyUp.text = $"초 당 재화 \n수급량 + {PerSecondMoney}";
        PerSecondMoneyDec.text = $"비용 : {PerSecondMoneyDecrease}";

    }
    IEnumerator Fever()
    {
        while (true)
        {
            if (slider.slMoney.value == slider.slMoney.maxValue)
            {
                FillColor.GetComponent<Image>().color = Color.cyan;
                Maximum.gameObject.SetActive(true);
            }
            else
            {
                FillColor.GetComponent<Image>().color = Color.green;
            }

            slider.slMoney.value += supplySpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void FeverSetButton()
    {
        if (Money >= FeverDecrease)
        {
            Money -= FeverDecrease;
            StartCoroutine(Fever());
            fever.SetActive(true);
            feverSetButton.SetActive(false);
        }
    }
    IEnumerator PerMoneyCount()
    {
        if (PerSecondMoneyLevel >= 1)
        {
            Money += PerSecondMoney;

        }
        yield return new WaitForSeconds(1);
        StartCoroutine(PerMoneyCount());
    }
    public void TouchUpgradeButton()
    {
        if (Money >= TouchMoneyDecrease)
        {
            TouchMoneyLevel++;
            Money -= TouchMoneyDecrease;
            TouchMoneyDecrease = Mathf.Round(TouchMoneyDecrease * 1.4f);
            TouchMoney += 2;
        }
    }
    public void PerSecondUpgradeButton()
    {
        if (Money >= PerSecondMoneyDecrease)
        {
            PerSecondMoneyLevel++;
            Money -= PerSecondMoneyDecrease;
            PerSecondMoneyDecrease = Mathf.Round(PerSecondMoneyDecrease * 1.25f);
            PerSecondMoney += 20;
        }
    }
 /*
    public void coroutine()
    {
        if(slider.slMoney.value == slider.slMoney.maxValue)
        StartCoroutine(FeverGauge());
    }
    public IEnumerator FeverGauge()
    {
        FeverOn = true;
            
        slider.slMoney.value = 0;
        Maximum.gameObject.SetActive(false);
        yield return new WaitForSeconds(10);
        FeverOn = false;
        TouchMoney = tabfever;
        PerSecondMoney = perfever;
    }
 */
}