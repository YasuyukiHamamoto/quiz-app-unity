using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ResultMgr : MonoBehaviour
{
    public GameObject returnPanel;
    //public GameObject haloImage;
    public Text resultText;
    public Text correctText;
    public Text wrongText;
    public Text answerRateText;
    //public Image resultImage;
    //public Sprite[] resultImageSprite;
    double answerRoundRate;
    string veryLowBounce = "ざんねん...\nもう一度挑戦!";
    string lowBounce = "まだまだ...\nもっとやれる!";
    string halfBounce = "あと少し!\nつぎは満点!";
    string fullBounce = "完璧!\n素晴らしい!!";

    void Start()
    {
        CalcAnswerRate();
        SetResultUIandSound();
        SetResultAnswer();
    }

    public void CalcAnswerRate()
    {
        double rate = (double)QuizMgr.correctCount / (double)QuizMgr.totalQuestinCount * 100;
        answerRoundRate = Math.Round(rate, MidpointRounding.AwayFromZero);
    }

    void SetResultUIandSound()
    {
        if (answerRoundRate < 30)
        {
            resultText.text = veryLowBounce;
            //resultImage.sprite = resultImageSprite[0];
            //haloImage.SetActive(false);
            SoundMgr.instance.PlaySE(4);

        }
        else if (answerRoundRate < 50)
        {
            resultText.text = lowBounce;
            //resultImage.sprite = resultImageSprite[1];
            //haloImage.SetActive(false);
            SoundMgr.instance.PlaySE(5);

        }
        else if (answerRoundRate < 100)
        {
            resultText.text = halfBounce;
            //resultImage.sprite = resultImageSprite[2];
            //haloImage.SetActive(false);
            SoundMgr.instance.PlaySE(6);

        }
        else
        {
            resultText.text = fullBounce;
            //resultImage.sprite = resultImageSprite[3];
            //haloImage.SetActive(true);
            SoundMgr.instance.PlaySE(7);

        }

    }

    void SetResultAnswer()
    {
        correctText.text = QuizMgr.correctCount.ToString();
        wrongText.text = QuizMgr.wrongCount.ToString();

        answerRateText.text = "正解率 " + answerRoundRate.ToString() + "%";
    }


    public void OnReturnStageButton()
    {
        SoundMgr.instance.PlaySE(0);
        returnPanel.SetActive(true);
    }

    public void OnReturnPanelReturnButton()
    {
        SoundMgr.instance.PlaySE(0);
        returnPanel.SetActive(false);
    }



}
