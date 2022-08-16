using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Silder slider; //�ǹ� �����̴��� �޾ƿ� ����
    public float supplySpeed = 1f; //�ǹ� �����̴��� ���� �ӵ�

    public static float Money = 0; //��ȭ
    [Header ("��ġ ����")]
    public Text TouchMoneyUp;
    public Text TouchMoneyDec;
    [Tooltip ("��ġ ��ȭ��")]
    public int TouchMoney = 1; //��ġ ��ȭ��
    [Tooltip("��ġ ��ȭ�� ����")]
    public int TouchMoneyLevel = 1; //��ġ ��ȭ�� ��ȭ����
    [Tooltip("��ġ ��ȭ�� ��ȭ �Ҹ�")]
    public float TouchMoneyDecrease = 10; //��ġ ��ȭ�� ��ȭ �Ҹ�
    [Header("�ʴ� ����")]
    public Text perSecondMoneyUp; 
    public Text PerSecondMoneyDec;
    [Tooltip("�ʴ� ��ȭ��")]
    public int PerSecondMoney = 0; //�ʴ� ��ȭ��
    [Tooltip("�ʴ� ��ȭ�� ����")]
    public int PerSecondMoneyLevel = 0; //�ʴ� ��ȭ�� ��ȭ����
    [Tooltip("�ʴ� ��ȭ�� ��ȭ �Ҹ�")]
    public float PerSecondMoneyDecrease = 150; //�ʴ� ��ȭ�� ��ȭ �Ҹ�
    [Space(10)]
    [Tooltip("�� ���� ��ȭ �Ҹ�")]
    public int[] ElementalFireUpgradeDecrease = new int[50]; //�� ���� ��ȭ �Ҹ�
    [Tooltip("�� ���� ��ȭ �Ҹ�")]
    public int[] ElementalWaterUpgradeDecrease = new int[50]; //�� ���� ��ȭ �Ҹ�
    [Tooltip("Ǯ ���� ��ȭ �Ҹ�")]
    public int[] ElementalGrassUpgradeDecrease = new int[10]; //Ǯ ���� ��ȭ �Ҹ�
    [Tooltip("�ٶ� ���� ��ȭ �Ҹ�")]
    public int[] ElementalWindUpgradeDecrease = new int[10]; //�ٶ� ���� ��ȭ �Ҹ�
    [Space(10)]
    [Tooltip("�� ���� ��ȭ ����")]
    public int ElementalFireLevel = 1; //�� ���� ��ȭ ����
    [Tooltip("�� ���� ��ȭ ����")]
    public int ElementalWaterLevel = 1; //�� ���� ��ȭ ����
    [Tooltip("Ǯ ���� ��ȭ ����")]
    public int ElementalGrassLevel = 1; //Ǯ ���� ��ȭ ����
    [Tooltip("�ٶ� ���� ��ȭ ����")]
    public int ElementalWindLevel = 1; //�ٶ� ���� ��ȭ ����
    [Space(10)]
    public bool ElementalFireOn = false;
    public bool ElementalWaterOn = false;
    public bool ElementalGrassOn = false;
    public bool ElementalWindOn = false;
    [Space(10)]
    public int[] ElementalFireMoney = new int[50];//�� ���� ��ġ�� ��ȭ ���޷�
    public int[] ElementalWaterMoney = new int[50]; //�� ���� �ʴ� ��ȭ ���޷�
    public int ElementalGrassMoney = 0; //Ǯ ���� ���Ѽ� �߰���
    public float[] ElementalWindMoney = new float[10]; //�ٶ� ���� �ǹ� ���� ���ð� ���ҷ�
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
    [Tooltip("��ȭ��")]
    public Text MoneyText;
    [Tooltip("��ġ �� ��ȭ")]
    public Text TouchResource;
    [Tooltip("�� �� ��ȭ")]
    public Text PerSecondResource;

    public static int count; 

    public GameObject Maximum;

    public GameObject FillColor;

    [Header("�ǹ� ����")]
    public Text FeverDec;
    public int FeverDecrease = 5000; //�ǹ� ���� �Ҹ�

    public int FeverTimeDecrease = 500000; //�ǹ� ���ӽð� ���� �Ҹ�

    public int FeverCooltimeDecrease = 600000; //�ǹ� ��Ÿ�� ���� �Ҹ�


    public GameObject fever;
    public int TouchEndFeverValue; //�ǹ��� ���� ���� ��ġ ��ȭ��
    public int PerEndFeverValue; //�ǹ��� ���� ���� �ʴ� ��ȭ��

    public float FeverTimeupgrade = 1.5f;
    public float FeverCooltimeUpgrade = 0.5f;

    public Text FeverTimeUp;
    public Text FeverTimeDec;

    public Text FeverCoolTimeUp;
    public Text FeverCoolTimeDec;

    public GameObject FeverSetButton; //�ǹ� ���� ��ư
    public GameObject FeverTimeButton; //�ǹ� ���ӽð� ��ư
    public GameObject FeverCoolTimeButton; //�ǹ� ��Ÿ�� ��ư
    public GameObject feverError;

    public bool FeverOn = false; //�ǹ� Ȱ��ȭ ����

    
    void Start()
    {
        slider = GameObject.Find("ExperienceSlider").GetComponent<Silder>();

        fever.SetActive(false);
        Maximum.SetActive(false);
        StartCoroutine(PerMoneyCount());
        FeverDec.text = $"��� : {FeverDecrease}";
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
        TouchResource.text = $"��ġ �� ��ȭ : {TouchMoney + ElementalFireMoney[ElementalFireMoneyLevel]}";
        PerSecondResource.text = $"�� �� ��ȭ : {PerSecondMoney + ElementalWaterMoney[ElementalWaterMoneyLevel]}";

        TouchMoneyUp.text = $"��ġ �� ��ȭ \n���޷� + {TouchMoney}";
        TouchMoneyDec.text = $"��� : {TouchMoneyDecrease}";

        perSecondMoneyUp.text = $"�� �� ��ȭ \n���޷� + {PerSecondMoney}";
        PerSecondMoneyDec.text = $"��� : {PerSecondMoneyDecrease}";

        //sFeverTimeUp.text = $"�ǹ� ���ӽð�\n���� + {}"

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
        while (!FeverOn) //�ǹ��� ������ �ʾ��� ��
        {
            if (slider.slMoney.value == slider.slMoney.maxValue)
                //�ǹ� �������� �� ����
            {
                FillColor.GetComponent<Image>().color = Color.cyan;
                //�������� ������ �ϴû����� �ٲٰ�
                Maximum.gameObject.SetActive(true);
                //��¦�̴� ������Ʈ�� ���̰� �Ѵ�
            }
            else //�� ���� ������
            {
                FillColor.GetComponent<Image>().color = Color.green;
                //�������� ������ �ʷϻ����� �ٲ۴�
            }

            slider.slMoney.value += (supplySpeed + ElementalWindMoney[ElementalWindMoneyLevel]); //�������� �ӵ���ŭ ���� ����
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void feverSetButton() //�ǹ� ���� ��ư
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
    IEnumerator PerMoneyCount() //�ʴ� ��ȭ ����
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
    public void TouchUpgradeButton() //��ġ ��ȭ�� ��ȭ
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
    public void PerSecondUpgradeButton() //�ʴ� ��ȭ�� ��ȭ
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
 
    public void coroutine() //��ư�� ������
    {
        //if(slider.slMoney.value == slider.slMoney.maxValue)
        StartCoroutine(FeverGauge()); //�ǹ� ������ �Ҹ� ����
    }
    public IEnumerator FeverGauge() //�ǹ� ������ �Ҹ� �ڷ�ƾ
    {
        if (slider.slMoney.value == slider.slMoney.maxValue)
        {
            FeverOn = true; //�ǹ� Ȱ��ȭ
            StopCoroutine(Fever());
            TouchEndFeverValue = TouchMoney; //���� ��ġ ��ȭ�� ����
            PerEndFeverValue = PerSecondMoney; //���� �ʴ� ��ȭ�� ����

            TouchMoney *= 2; //��ġ�� ���� �� *2
            PerSecondMoney *= 2;//�ʴ� ���� �� *2

            Maximum.gameObject.SetActive(false);
            while (slider.slMoney.value > 0) //�ǹ� �������� 0�� �� ������
            {
                slider.slMoney.value -= 3; // �ǹ� �������� ������ �پ���
                yield return new WaitForSeconds(0.1f);
            }
            TouchMoney = TouchEndFeverValue; //��ġ ��ȭ���� ������� ��������
            PerSecondMoney = PerEndFeverValue; // �ʴ� ��ȭ���� ������� ��������
            FeverOn = false; //�ǹ� ��Ȱ��ȭ
            StartCoroutine(Fever()); //�ǹ� ������ ���� �ڷ�ƾ �����
        }
    }
 
    IEnumerator FeverOnError() //�ǹ� �� ��ȭ�Ұ�
    {
        feverError.SetActive(true);
        yield return new WaitForSeconds(1);
        feverError.SetActive(false);
    }
    
}