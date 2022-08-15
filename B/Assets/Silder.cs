using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Silder : MonoBehaviour
{
    public Slider slMoney;
    public Text slValue;
    GameManager gameManager;
    

    void OnEnable()
    {
        slMoney = GetComponent<Slider>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Slider();
    }
    void Slider()
    {
        
        string format = string.Format("{0:0}", slMoney.value / 500 * 100) + "%";
        if (slMoney.value != slMoney.maxValue && gameManager.FeverOn == false) slValue.text = format;

        else if (slMoney.value == slMoney.maxValue) slValue.text = "Fever!";

        if (slMoney.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);
    }
}
