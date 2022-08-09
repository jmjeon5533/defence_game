using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Silder : MonoBehaviour
{
    public Slider slMoney;
    public Text slValue;
    public Text[] Decrease = new Text[4];
    GameManager gameManager;

    void Start()
    {
        slMoney = GetComponent<Slider>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Slider();
        ButtonDecrease();
    }
    void ButtonDecrease()
    {
        Decrease[0].text = $"{gameManager.firstbuttonDecrease}";
        Decrease[1].text = $"{gameManager.secondbuttonDecrease}";
        Decrease[2].text = $"{gameManager.thirdbuttonDecrease}";
        Decrease[3].text = $"{gameManager.supplyMoneyDecrease}";
    }
    void Slider()
    {
        slValue.text = $"{slMoney.value}";
        if (slMoney.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);
    }
}
