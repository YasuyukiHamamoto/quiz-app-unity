using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Judge : MonoBehaviour
{
    //public QuizMgr quizMgr;
    public void OnClickButton()
    {
        JudgeAns();
        SoundMgr.instance.PlaySE(0);
    }


    public void JudgeAns()
    {
        string ansText;
        Text selectText = this.GetComponentInChildren<Text>();

        if (QuizMgr.IsTimeAttackFlag())
        {
            ansText = QuizMgr.quesitonTable[QuizMgr.quesionNumbers[0]][3];
        }
        else
        {
            ansText = QuizMgr.quizTable[QuizMgr.quesionNumbers[0]][3];
        }


        if (selectText.text == ansText)
        {
            SceneManager.LoadScene("ResultCorrect");
            QuizMgr.correctCount++;

        }
        else
        {
            SceneManager.LoadScene("ResultWrong");
            QuizMgr.wrongCount++;
            QuizMgr.lifeCount--;
            
        }
    }
}
