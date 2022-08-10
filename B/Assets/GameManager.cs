using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Silder slider;
    public float supplySpeed = 1f;

    

    public static int Level = 1;

    public static int Money = 0;

    public static int count;

    public GameObject Maximum;

    public GameObject FillColor;

    public GameObject fever;

    public GameObject feverSetButton;
    void Start()
    {
        slider = GameObject.Find("ExperienceSlider").GetComponent<Silder>();

        StartCoroutine(Count());
        fever.SetActive(false);
        Maximum.SetActive(false);
        
    }

    
    void Update()
    {
        
    }
    
    IEnumerator Fever()
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
        StartCoroutine(Fever());
    }
    IEnumerator Count()
    {
        yield return new WaitForSecondsRealtime(1);
        count++;
    }
    public void FeverSetButton()
    {
        StartCoroutine(Fever());
        fever.SetActive(true);
        feverSetButton.SetActive(false);
    }
}
