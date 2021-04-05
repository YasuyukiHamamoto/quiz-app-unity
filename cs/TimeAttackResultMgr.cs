using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAttackResultMgr : MonoBehaviour
{
    public GameObject rewardsPanel;
    public GameObject returnPanel;
    public Text correctText;
    int restCount;

    // Start is called before the first frame update
    void Start()
    {
        SetCorrectText();
        SetGameOverAudio();
    }

    void SetGameOverAudio()
    {
        SoundMgr.instance.PlaySE(5);
    }

    void SetCorrectText()
    {
        restCount = QuizMgr.totalQuestinCount - (QuizMgr.gameCount +1);

        correctText.text = "残り"+ restCount.ToString() + "問!" ;
    }

    
    public void OnContinueButton()
    {
        SoundMgr.instance.PlaySE(0);
        rewardsPanel.SetActive(true);
    }

    public void OnRewardsPanelReturnButton()
    {
        SoundMgr.instance.PlaySE(0);
        rewardsPanel.SetActive(false);
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
