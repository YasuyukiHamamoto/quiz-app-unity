using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{

    public void NextQuiz()
    {
        if (QuizMgr.IsTimeAttackFlag())
        {
            if (QuizMgr.lifeCount == -3)
            {

                SceneManager.LoadScene("GameOver");

            }
            else
            {
                QuizMgr.ExceptRandomList();
                if (QuizMgr.gameCount >= QuizMgr.totalQuestinCount)
                {
                      SceneManager.LoadScene("Clear");
                }
                else
                {
                    SceneManager.LoadScene("Main");

                }
            }
        }
        else
        {
            QuizMgr.ExceptRandomList();
            if (QuizMgr.gameCount >= QuizMgr.totalQuestinCount)
            {
                SceneManager.LoadScene("Result");
            }
            else
            {
                SceneManager.LoadScene("Main");

            }
        }
      
    }

    public void OnNextButton()
    {
        SoundMgr.instance.PlaySE(0);
        NextQuiz();
    }


    public void OnKimarijiKamiButton()
    {
        QuizMgr.selectNumber = 1;
        QuizMgr.selectKey = "決まり字上の句";
        SoundMgr.instance.PlaySE(0);
        SceneManager.LoadScene("Ready");

    }

    public void OnKimarijiShimoButton()
    {
        QuizMgr.selectNumber = 1;
        QuizMgr.selectKey = "決まり字下の句";
        SoundMgr.instance.PlaySE(0);
        SceneManager.LoadScene("Ready");

    }

    public void OnKaminokuButton()
    {
        QuizMgr.selectNumber = 1;
        QuizMgr.selectKey = "上の句";
        SoundMgr.instance.PlaySE(0);
        SceneManager.LoadScene("Ready");

    }

    public void OnShimonokuButton()
    {
        QuizMgr.selectNumber = 1;
        QuizMgr.selectKey = "下の句";
        SoundMgr.instance.PlaySE(0);
        SceneManager.LoadScene("Ready");

    }

    public void OnRetryButton()
    {
        QuizMgr.RetryClearList();
        SceneManager.LoadScene("Main");
    }

    public void OnTopButton()
    {
        QuizMgr.AllClearList();
        SoundMgr.instance.PlaySE(0);
        SceneManager.LoadScene("Title");

    }

    public void OnTimeAttackeButton()
    {
        QuizMgr.timeAttackFlag = 1;
        SoundMgr.instance.PlaySE(0);
        SceneManager.LoadScene("Ready");

    }

    /*
    public void OnLevelButton()
    {
        SceneManager.LoadScene("LevelSelect");
        SoundMgr.instance.PlaySE(0);



    }

    public void OnCategoryButton()
    {
        SceneManager.LoadScene("CategorySelect");
        SoundMgr.instance.PlaySE(0);

    }

    public void OnMusicButton()
    {
        QuizMgr.selectNumber = 1;
        QuizMgr.selectKey = "ミュージック";
        SoundMgr.instance.PlaySE(0);

        SceneManager.LoadScene("Ready");
    }

    public void OnMusicRoleButton()
    {
        QuizMgr.selectNumber = 1;
        QuizMgr.selectKey = "歌割り";
        SoundMgr.instance.PlaySE(0);

        SceneManager.LoadScene("Ready");
    }

    public void OnLiveButton()
    {
        QuizMgr.selectNumber = 1;
        QuizMgr.selectKey = "ライブ";
        SoundMgr.instance.PlaySE(0);

        SceneManager.LoadScene("Ready");
    }

    public void OnCountDownButton()
    {
        QuizMgr.selectNumber = 1;
        QuizMgr.selectKey = "カウコン";
        SoundMgr.instance.PlaySE(0);

        SceneManager.LoadScene("Ready");
    }


    public void OnProfileButton()
    {
        QuizMgr.selectNumber = 1;
        QuizMgr.selectKey = "プロフィール";
        SoundMgr.instance.PlaySE(0);

        SceneManager.LoadScene("Ready");
    }

    public void OnHistoryButton()
    {
        QuizMgr.selectNumber = 1;
        QuizMgr.selectKey = "ヒストリー";
        SoundMgr.instance.PlaySE(0);

        SceneManager.LoadScene("Ready");
    }

    */

    public void OnGameStart()
    {
        SceneManager.LoadScene("Main");
        SoundMgr.instance.PlaySE(0);

    }

    public void ToStageSelectButton()
    {
        SoundMgr.instance.PlaySE(0);
        SceneManager.LoadScene("StageSelect");

    }

    public void OnResetAndStageSelectButton()
    {
        QuizMgr.AllClearList();
        SceneManager.LoadScene("StageSelect");

    }


}
