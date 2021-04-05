using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    //カウントダウン
    public float countdown;

    //時間を表示するText型の変数
    public Text timeText;

    public Slider timeSlider;

    //バナー広告の消去イベント
    public UnityEvent DestroyBannerAd;


    private void Start()
    {
        timeSlider.value = countdown;
    }

    // Update is called once per frame

    void Update()
    {
        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            timeText.text = "0.0";
            DestroyBannerAd.Invoke();
            QuizMgr.lifeCount--;
            SceneManager.LoadScene("ResultWrong");

        }
        else
        {
            //時間をカウントダウンする
            countdown -= Time.deltaTime;

            //時間をスライダーのValueに反映する
            timeSlider.value = countdown;

            //時間を表示する
            timeText.text = countdown.ToString("f1");
        }

    }
    
}
