using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Silder slider; //피버 슬라이더를 받아올 변수
    public float supplySpeed = 1f; //피버 슬라이더가 차는 속도

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
    [Space(10)]
    [Tooltip("불 원소 강화 소모량")]
    public int[] ElementalFireUpgradeDecrease = new int[50]; //불 원소 강화 소모량
    [Tooltip("물 원소 강화 소모량")]
    public int[] ElementalWaterUpgradeDecrease = new int[50]; //물 원소 강화 소모량
    [Tooltip("풀 원소 강화 소모량")]
    public int[] ElementalGrassUpgradeDecrease = new int[10]; //풀 원소 강화 소모량
    [Tooltip("바람 원소 강화 소모량")]
    public int[] ElementalWindUpgradeDecrease = new int[10]; //바람 원소 강화 소모량
    [Space(10)]
    [Tooltip("불 원소 강화 레벨")]
    public int ElementalFireLevel = 1; //불 원소 강화 레벨
    [Tooltip("물 원소 강화 레벨")]
    public int ElementalWaterLevel = 1; //물 원소 강화 레벨
    [Tooltip("풀 원소 강화 레벨")]
    public int ElementalGrassLevel = 1; //풀 원소 강화 레벨
    [Tooltip("바람 원소 강화 레벨")]
    public int ElementalWindLevel = 1; //바람 원소 강화 레벨
    [Space(10)]
    public bool ElementalFireOn = false;
    public bool ElementalWaterOn = false;
    public bool ElementalGrassOn = false;
    public bool ElementalWindOn = false;
    [Space(10)]
    public int[] ElementalFireMoney = new int[50];//불 원소 터치당 재화 수급량
    public int[] ElementalWaterMoney = new int[50]; //물 원소 초당 재화 수급량
    public int ElementalGrassMoney = 0; //풀 원소 상한선 추가량
    public float[] ElementalWindMoney = new float[10]; //바람 원소 피버 재사용 대기시간 감소량
    [Space(10)]
    public int ElementalFireMoneyLevel = 0;
    public int ElementalWaterMoneyLevel = 0;
    public int ElementalGrassMoneyLevel = 0;
    public int ElementalWindMoneyLevel = 0;
    [Space(10)]
    public int ElementalNumber = 0;
    [Space(5)]
    public int ElementalMaxNum = 20;
    public bool ElementalMaximum = false;
    public GameObject ElementalMax;
    public Text ElementalN;
    [Space(10)]
    public int ElementalFireNumber = 0;
    public int ElementalWaterNumber = 0;
    public int ElementalGrassNumber = 0;
    public int ElementalWindNumber = 0;
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

    public int FeverTimeDecrease = 500000; //피버 지속시간 증가 소모량

    public int FeverCooltimeDecrease = 600000; //피버 쿨타임 감소 소모량


    public GameObject fever;
    public int TouchEndFeverValue; //피버가 끝난 후의 터치 재화량
    public int PerEndFeverValue; //피버가 끝난 후의 초당 재화량

    public float FeverTimeupgrade = 1.5f;
    public float FeverCooltimeUpgrade = 0.5f;

    public Text FeverTimeUp;
    public Text FeverTimeDec;

    public Text FeverCoolTimeUp;
    public Text FeverCoolTimeDec;

    public GameObject FeverSetButton; //피버 구매 버튼
    public GameObject FeverTimeButton; //피버 지속시간 버튼
    public GameObject FeverCoolTimeButton; //피버 쿨타임 버튼
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
        MoneyUI();
        Cheat();
        ElementalNum();

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos += new Vector2(0, 1.5f);

            Ray2D ray;
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.back, 100f, LayerMask.GetMask("MoneyPack"));
            if (hit)
            {
                Destroy(hit.collider.gameObject);
                Money += 10000;
            }
        }
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
        TouchResource.text = $"터치 당 재화 : {TouchMoney + ElementalFireMoney[ElementalFireMoneyLevel]}";
        PerSecondResource.text = $"초 당 재화 : {PerSecondMoney + ElementalWaterMoney[ElementalWaterMoneyLevel]}";

        TouchMoneyUp.text = $"터치 당 재화 \n수급량 + {TouchMoney}";
        TouchMoneyDec.text = $"비용 : {TouchMoneyDecrease}";

        perSecondMoneyUp.text = $"초 당 재화 \n수급량 + {PerSecondMoney}";
        PerSecondMoneyDec.text = $"비용 : {PerSecondMoneyDecrease}";

        //sFeverTimeUp.text = $"피버 지속시간\n증가 + {}"

        ElementalN.text = $"{ElementalNumber}/{ElementalMaxNum}";

    }
    public void ElementalNum()
    {
        ElementalNumber = (
            ElementalFireNumber
            + ElementalWaterNumber
            + ElementalGrassNumber
            + ElementalWindNumber);
        if (ElementalMaxNum == ElementalNumber) ElementalMaximum = true;
    }
    public void ElementalError()
    {
        StartCoroutine(ElementErr());
    }
    IEnumerator ElementErr()
    {
        ElementalMax.SetActive(true);
        yield return new WaitForSeconds(1);
        ElementalMax.SetActive(false);
    }
    IEnumerator Fever() 
    {
        while (!FeverOn) //피버를 누르지 않았을 때
        {
            if (slider.slMoney.value == slider.slMoney.maxValue)
                //피버 게이지가 꽉 차면
            {
                FillColor.GetComponent<Image>().color = Color.cyan;
                //게이지의 색깔을 하늘색으로 바꾸고
                Maximum.gameObject.SetActive(true);
                //반짝이는 오브젝트를 보이게 한다
            }
            else //꽉 차지 않으면
            {
                FillColor.GetComponent<Image>().color = Color.green;
                //게이지의 색깔을 초록색으로 바꾼다
            }

            slider.slMoney.value += (supplySpeed + ElementalWindMoney[ElementalWindMoneyLevel]); //게이지가 속도만큼 점점 찬다
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void feverSetButton() //피버 구매 버튼
    {
        if (Money >= FeverDecrease)
        {
            Money -= FeverDecrease;
            StartCoroutine(Fever());
            fever.SetActive(true);
            FeverSetButton.SetActive(false);
        }
    }
    public void FeverTimeUpgrade()
    {
        if (Money >= FeverTimeDecrease)
        {
            Money -= FeverTimeDecrease;
            FeverTimeButton.SetActive(false);
        }
    }
    public void FeverCoolTimeUpgrade()
    {
        if (Money >= FeverCooltimeDecrease)
        {
            Money -= FeverCooltimeDecrease;
            FeverCoolTimeButton.SetActive(false);
        }
    }
    IEnumerator PerMoneyCount() //초당 재화 수급
    {
        if (PerSecondMoneyLevel >= 1)
        {
            Money += PerSecondMoney;
            Money +=
                ElementalWaterMoney[ElementalWaterMoneyLevel];
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
                TouchMoneyDecrease = Mathf.Round(TouchMoneyDecrease * 1.15f);
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
            while (slider.slMoney.value > 0) //피버 게이지가 0이 될 때까지
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