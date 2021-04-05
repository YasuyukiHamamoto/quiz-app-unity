using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnsResult : MonoBehaviour
{
    public GameObject menuPanel;

    private void Start()
    {
        AnsCommentary();
    }

    public void AnsCommentary()
    {
        string ansText;
        if (QuizMgr.IsTimeAttackFlag())
        {
            ansText = QuizMgr.quesitonTable[QuizMgr.quesionNumbers[0]][3];
        }
        else
        {
            ansText = QuizMgr.quizTable[QuizMgr.quesionNumbers[0]][3];
        }
        Text selectText = this.GetComponentInChildren<Text>();
        selectText.text = ansText;
    }


}
