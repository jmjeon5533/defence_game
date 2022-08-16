using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class Button : MonoBehaviour
{
    //크레딧 박스
    public GameObject Credit;
    //배경, 제목
    public Image Fade_BackGround;
    public Image Fade_Title;

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("InGame");
    }

    public void OnClickCreditButton()
    {
        FadeInOut(0.2f, 1.5f);
        Credit.transform.DOLocalMove(new Vector3(0, 0, 0), 1.5f).SetEase(Ease.OutBack);
    }

    public void OnClickHomeButton()
    {
        FadeInOut(1, 1.5f);
        Credit.transform.DOLocalMove(new Vector3(0, 3000, 0), 1.5f).SetEase(Ease.InBack);
    }

    void FadeInOut(float FadeValue, float Time)
    {
        Fade_BackGround.DOFade(FadeValue, Time);
        Fade_Title.DOFade(FadeValue, Time);
    }
}
