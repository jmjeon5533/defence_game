using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Silder slider; //슬라이더를 받아올 변수
    public float supplySpeed = 1f; //슬라이더가 차는 속도

    public static float Money = 0; //재화
    [Header ("터치 관련")]
    public Text TouchMoneyUp;
    public Text TouchMoneyDec;
    [Tooltip ("터치 재화량")]
    public int TouchMoney = 1; //터치 재화량
    [Tooltip("터치 재화량 레벨")]
    public int TouchMoneyLevel = 1; //터치 재화량 강화레벨
    [Tooltip("터치 재화량 강화 소모량")]
    public float TouchMoneyDecrease = 10; //터치 재화량 강화 소모량
    [Header("초당 관련")]
    public Text perSecondMoneyUp; 
    public Text PerSecondMoneyDec;
    [Tooltip("초당 재화량")]
    public int PerSecondMoney = 0; //초당 재화량
    [Tooltip("초당 재화량 레벨")]
    public int PerSecondMoneyLevel = 0; //초당 재화량 강화레벨
    [Tooltip("초당 재화량 강화 소모량")]
    public float PerSecondMoneyDecrease = 150; //초당 재화량 강화 소모량

    [Header("원소 관련")]
    [Tooltip("불 원소 영입 소모량")]
    public int ElementalFireDecrease = 10000; //불 원소 영입 소모량
    [Tooltip("물 원소 영입 소모량")]
    public int ElementalWaterDecrease; //물 원소 영입 소모량
    [Tooltip("풀 원소 영입 소모량")]
    public int ElementalGrassDecrease; //풀 원소 영입 소모량
    [Tooltip("바람 원소 영입 소모량")]
    public int ElementalWindDecrease; //바람 원소 영입 소모량
    [Space (10)]
    [Tooltip("불 원소 강화 소모량")]
    public int ElementalFireUpgradeDecrease; //불 원소 강화 소모량
    [Tooltip("물 원소 강화 소모량")]
    public int ElementalWaterUpgradeDecrease; //물 원소 강화 소모량
    [Tooltip("풀 원소 강화 소모량")]
    public int ElementalGrassUpgradeDecrease; //풀 원소 강화 소모량
    [Tooltip("바람 원소 강화 소모량")]
    public int ElementalWindUpgradeDecrease; //바람 원소 강화 소모량
    [Space(10)]
    public bool ElementalFireOn = false;
    public bool ElementalWaterOn = false;
    public bool ElementalGrassOn = false;
    public bool ElementalWindOn = false;
    [Space(10)]
    [Tooltip("재화량")]
    public Text MoneyText;
    [Tooltip("터치 당 재화")]
    public Text TouchResource;
    [Tooltip("초 당 재화")]
    public Text PerSecondResource;

    public static int count; 

    public GameObject Maximum;

    public GameObject FillColor;

    [Header("피버 관련")]
    public Text FeverDec;
    public int FeverDecrease = 5000; //피버 구매 소모량

    public GameObject fever;
    public int TouchEndFeverValue; //피버가 끝난 후의 터치 재화량
    public int PerEndFeverValue; //피버가 끝난 후의 초당 재화량
    public GameObject feverSetButton;
    public GameObject feverError;

    public bool FeverOn = false; //피버 활성화 유무

    
    void Start()
    {
        slider = GameObject.Find("ExperienceSlider").GetComponent<Silder>();

        fever.SetActive(false);
        Maximum.SetActive(false);
        StartCoroutine(PerMoneyCount());
        FeverDec.text = $"비용 : {FeverDecrease}";
        feverError.SetActive(false);
    }


    void Update()
    {
        Cheat();
        MoneyUI();
    }
    void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Money += 10000;
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
        while (!FeverOn)
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
    public void FeverSetButton() //피버 구매 버튼
    {
        if (Money >= FeverDecrease)
        {
            Money -= FeverDecrease;
            StartCoroutine(Fever());
            fever.SetActive(true);
            feverSetButton.SetActive(false);
        }
    }
    IEnumerator PerMoneyCount() //초당 재화 수급
    {
        if (PerSecondMoneyLevel >= 1)
        {
            Money += PerSecondMoney;

        }
        yield return new WaitForSeconds(1);
        StartCoroutine(PerMoneyCount());
    }
    public void TouchUpgradeButton() //터치 재화량 강화
    {
        if (Money >= TouchMoneyDecrease)
        {
            if (!FeverOn)
            {
                TouchMoneyLevel++;
                Money -= TouchMoneyDecrease;
                TouchMoneyDecrease = Mathf.Round(TouchMoneyDecrease * 1.1f);
                TouchMoney += 2;
            }
            else
            {
                StartCoroutine(FeverOnError());
            }
        }
    }
    public void PerSecondUpgradeButton() //초당 재화량 강화
    {
        if (Money >= PerSecondMoneyDecrease)
        {
            if (!FeverOn)
            {
                PerSecondMoneyLevel++;
                Money -= PerSecondMoneyDecrease;
                PerSecondMoneyDecrease = Mathf.Round(PerSecondMoneyDecrease * 1.2f);
                PerSecondMoney += 20;
            }
            else
            {
                StartCoroutine(FeverOnError());
            }
        }
    }
 
    public void coroutine() //버튼을 누르면
    {
        //if(slider.slMoney.value == slider.slMoney.maxValue)
        StartCoroutine(FeverGauge()); //피버 게이지 소모 시작
    }
    public IEnumerator FeverGauge() //피버 게이지 소모 코루틴
    {
        if (slider.slMoney.value == slider.slMoney.maxValue)
        {
            FeverOn = true; //피버 활성화
            StopCoroutine(Fever());
            TouchEndFeverValue = TouchMoney; //원본 터치 재화값 저장
            PerEndFeverValue = PerSecondMoney; //원본 초당 재화값 저장

            TouchMoney *= 2; //터치로 버는 돈 *2
            PerSecondMoney *= 2;//초당 버는 돈 *2

            Maximum.gameObject.SetActive(false);
            while (slider.slMoney.value > 0) //피버 게이지가 0이 될 동안
            {
                slider.slMoney.value -= 3; // 피버 게이지를 서서히 줄어들게
                yield return new WaitForSeconds(0.1f);
            }
            TouchMoney = TouchEndFeverValue; //터치 재화값을 원래대로 돌려놓기
            PerSecondMoney = PerEndFeverValue; // 초당 재화값을 원래대로 돌려놓기
            FeverOn = false; //피버 비활성화
            StartCoroutine(Fever()); //피버 게이지 충전 코루틴 재실행
        }
    }
 
    IEnumerator FeverOnError() //피버 중 강화불가
    {
        feverError.SetActive(true);
        yield return new WaitForSeconds(1);
        feverError.SetActive(false);
    }
}