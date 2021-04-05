using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearResultMgr : MonoBehaviour
{
    public GameObject returnPanel;
    public Text continueText;
    public Text correctText;

    // Start is called before the first frame update
    void Start()
    {
        SetRecordText();
    }

    void SetRecordText()
    {
        continueText.text = "コンティニュー回数　" + QuizMgr.continueCount.ToString() + "回";
        correctText.text = "正解数　" + QuizMgr.correctCount.ToString() + "問";
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
