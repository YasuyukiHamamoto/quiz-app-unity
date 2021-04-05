using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizMgr : MonoBehaviour
{
    // 問題リストCSVファイルからテキストデータとして配列で読み込み
    // 読み込んだデータを区切り文字でさらに2次元配列で取り込み。


    // 問題リストからランダムで問題を抽出
    // 選択した問題の中で、回答をランダムにセット。

    //答えを選択したら、正誤判定
    //次の問題へ遷移（出題する問題は、最初の時点でセット完了しているはず。）
    //ただし、シーンを移動するとデータが破壊されるため、受け渡しが必要。
    //特に問題文を重複がないようにするにはどうするか？


    public TextAsset questionFile;
    public Text questionText;
    public Text[] ansText;
    public Text quesitonCountText;
    public Text categoryText;
    public Text correctCountText;
    public Text wrongCountText;
    public short numberOfChoice;
    public short numberOfQuestion;
    public static short listLengh;
    public static string selectKey;
    public static short selectNumber;
    public static short gameCount;
    public static short correctCount;
    public static short wrongCount;
    public static short lifeCount;
    public static short? timeAttackFlag;
    public static short totalQuestinCount;
    public static short continueCount;
    public static List<List<string>> quesitonTable;
    public static List<List<string>> quizTable;
    public static List<int> quesionNumbers;
    public Image[] levelImage;
    public Sprite[] levelSprite;
    public GameObject[] lifeImage;
    public GameObject resultPanel;
    public GameObject lifePanel;
    public GameObject centerPanel;
    public GameObject timeAttackCenterPanel;
    public GameObject timeManager;
    public GameObject menuPanel;

    private void Awake()
    {
        LoadQuestionFromText();
        LoadQuizTable();
    }

    private void Start()
    {
        SetTotalQuestionCount();
        CreatRandomList();
        SetQuestionLabel();
        SetAnsLabel();
        SetQuestionCount();
        SetTopLabel();
        SetCenterPanel();
        SetTimeManager();
    }


    void SetQuestionLabel()
    {
        string qLabel;

        if (IsTimeAttackFlag())
        {
            qLabel = quesitonTable[quesionNumbers[0]][2];
        }
        else
        {
            qLabel = quizTable[quesionNumbers[0]][2];
        }

        questionText.text = qLabel;
        //Debug.Log(qLabel);
    }


    void SetQuestionCount()
    {
        quesitonCountText.text = "問 "+ (gameCount +1) + " / "+ totalQuestinCount;
    }

    public bool IsQuestionTable()
    {
        if (quesitonTable == null)
        {
            return true;
        }
        return false;
    }

    public bool IsRamdomList()
    {
        if (quesionNumbers == null)
        {
            return true;
        }
        return false;
    }

    public bool IsQuizTable()
    {
        if (quizTable == null)
        {
            return true;
        }
        return false;
    }

    public static bool IsTimeAttackFlag()
    {
        if (timeAttackFlag == 1)
        {
            return true;
        }

        return false;

    }

    public static void SetTotalQuestionCount()
    {
        if (IsTimeAttackFlag())
        {
            totalQuestinCount = 25;
        }
        else
        {
            totalQuestinCount = 10;
        }
    }

    public void LoadQuestionFromText()
    {
        if (IsQuestionTable())
        {
            quesitonTable = new List<List<string>>(500);

            string loadText = questionFile.text.Replace(" ", "\u00A0");
            string[] lines = loadText.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
            listLengh = (short)lines.Length;

            for (int i = 0; i < listLengh; i++)
            {
                string[] values = lines[i].Split(new[] { ',' });
                for (int j = 0; j < values.Length; j++)
                {
                    quesitonTable.Add(new List<string>(10));
                    quesitonTable[i].Add(values[j]);
                    Debug.Log(quesitonTable[i][j]);
                }
            }
        }
    }

    public void LoadQuizTable()
    {

        if (IsQuizTable())
        {
            // 出題用テーブルを生成する関数

            // 出題用リストの初期化
            quizTable = new List<List<string>>(500);

            int row = 0;

            for (int i = 0; i < listLengh; i++)
            {
                if (quesitonTable[i][selectNumber] == selectKey)
                //if (quesitonTable[i][0] == "やさしい")
                {
                    for (int j = 0; j < quesitonTable[i].Count; j++)
                    {
                        quizTable.Add(new List<string>(10));
                        quizTable[row].Add(quesitonTable[i][j]);
                        //Debug.Log(quizTable[row][j]);

                    }

                    row++;

                }
            }
        }


    }

    void CreatRandomList()
    {
        // 出題用テーブルからランダムに問題を生成するための関数


        if (IsRamdomList())
        {
            quesionNumbers = new List<int>(50);
            int max;

            // タイムアタックと通常問題では出題数が異なるため判別
            // 出題用テーブルの最大値を取得
            if (IsTimeAttackFlag())
            {
                max = listLengh;
                Debug.Log(max);
            }
            else
            {
                max = quizTable.Count / quizTable[0].Count;
                Debug.Log(max);

            }

            //リストに出題用テーブルの範囲内の数をランダムにリストに入れる

            while (quesionNumbers.Count < totalQuestinCount)
            {
                int n = Random.Range(0, max);
                if (quesionNumbers.Contains(n))
                {
                    //Debug.Log("何もしない、もう一度ランダム生成");
                }
                else
                {
                    quesionNumbers.Add(n);
                }
            }

        }
    }

    public static void ExceptRandomList()
    {
        // 回答していく毎に出題番号指定リストから値を削除する関数
        // UI用に現在の問題数を増やしていく。
        quesionNumbers.RemoveAt(0);
        gameCount++;
    }

    void SetAnsLabel()
    {
        // 回答欄に回答選択肢をランダムに入れ込む関数

        // リストに、テキストデータで読み込みんだ列数の数字をランダムに入れ込む
        List<int> ns = new List<int>();

        while (ns.Count < numberOfChoice)
        {
            int n = Random.Range(3, 7);
            if (ns.Contains(n))
            {
                //Debug.Log("何もしない、もう一度ランダム生成");
            }
            else
            {
                ns.Add(n);
            }
        }

        // 上記のリストを参照して出題用テーブルから選択肢をセットする。

        for (short i = 0; i < numberOfChoice; i++)
        {
            if (IsTimeAttackFlag())
            {
                ansText[i].text = quesitonTable[quesionNumbers[0]][ns[i]];

            }
            else
            {
                ansText[i].text = quizTable[quesionNumbers[0]][ns[i]];

            }
            //Debug.Log(ansText[i].text);
        }

    }

    void SetTopLabel()
    {
        if (IsTimeAttackFlag())
        {
            SetLevelUI();
            SetCategoryUI();
            SetLifeUI();
        } 
        else
        {
            SetLevelUI();
            SetCategoryUI();
            SetResultUI();
        }
    }

    void SetLevelUI()
    {
        // 出題用テーブルの難易度列の値を参照してUIに反映する関数

        // 各問の難易度を取得する
        string selectTable;

        if (IsTimeAttackFlag())
        {
            selectTable = quesitonTable[quesionNumbers[0]][0];
        }
        else
        {
            selectTable = quizTable[quesionNumbers[0]][0];
        }

        // 取得した難易度によってUIを変更する

        switch (selectTable)
        {
            case "やさしい":
                levelImage[0].sprite = levelSprite[1];
                levelImage[1].sprite = levelSprite[0];
                levelImage[2].sprite = levelSprite[0];
                levelImage[3].sprite = levelSprite[0];
                break;

            case "ふつう":
                levelImage[0].sprite = levelSprite[1];
                levelImage[1].sprite = levelSprite[1];
                levelImage[2].sprite = levelSprite[0];
                levelImage[3].sprite = levelSprite[0];
                break;

            case "むずかしい":
                levelImage[0].sprite = levelSprite[1];
                levelImage[1].sprite = levelSprite[1];
                levelImage[2].sprite = levelSprite[1];
                levelImage[3].sprite = levelSprite[0];
                break;

            case "げきむず":
                levelImage[0].sprite = levelSprite[1];
                levelImage[1].sprite = levelSprite[1];
                levelImage[2].sprite = levelSprite[1];
                levelImage[3].sprite = levelSprite[1];
                break;

        }
    }

    void SetCategoryUI()
    {
        // 出題用テーブルのジャンル列の値を参照してUIに反映する関数

        if (IsTimeAttackFlag())
        {
            categoryText.text = "ジャンル:" + quesitonTable[quesionNumbers[0]][1];
        }
        else
        {
            categoryText.text = "ジャンル:" + quizTable[quesionNumbers[0]][1];
        }

    }

    void SetResultUI()
    {
        // 現状の正解・不正解の数をUIに反映する関数

        // タイムアタックと通常問題のUIが異なるため判別

        if (IsTimeAttackFlag())
        {
            lifePanel.SetActive(false);
            resultPanel.SetActive(true);
        }
        else
        {
            lifePanel.SetActive(false);
            resultPanel.SetActive(true);
        }

        // 現状の正解・不正解数をテキストに変換してUIに反映

        correctCountText.text = correctCount.ToString();
        wrongCountText.text = wrongCount.ToString();

    }

    

    void SetLifeUI()
    {
        // タイムアタック時に使用する残りライフをUIに反映する関数

        // タイムアタックと通常問題のUIが異なるため判別

        if (IsTimeAttackFlag())
        {
            lifePanel.SetActive(true);
            resultPanel.SetActive(false);
        }
        else
        {
            lifePanel.SetActive(false);
            resultPanel.SetActive(true);
        }

        // 取得した残りライフ数によってUIを変更する

        switch (lifeCount)
        {
            case 0:
                lifeImage[0].SetActive(true);
                lifeImage[1].SetActive(true);
                lifeImage[2].SetActive(true);
                break;

            case -1:
                lifeImage[0].SetActive(true);
                lifeImage[1].SetActive(true);
                lifeImage[2].SetActive(false);
                break;

            case -2:
                lifeImage[0].SetActive(true);
                lifeImage[1].SetActive(false);
                lifeImage[2].SetActive(false);
                break;

        }
    }

    void SetCenterPanel()
    {
        // 真ん中らのUIを切り替える関数

        // タイムアタックと通常問題のUIが異なるため判別
        // 結果によって、表示・非表示を切り替える

        if (IsTimeAttackFlag())
        {
            centerPanel.SetActive(false);
            timeAttackCenterPanel.SetActive(true);
        }
        else
        {
            centerPanel.SetActive(true);
            timeAttackCenterPanel.SetActive(false);

        }
    }

    void SetTimeManager()
    {
        if (IsTimeAttackFlag())
        {
            timeManager.SetActive(true);
        }
        else
        {
            timeManager.SetActive(false);

        }

    }

    
    public static void RetryClearList()
    {
        // 再挑戦ボタンを押した時に各変数をリセットする関数
        // 同じジャンルを再度挑戦するため、出題用テーブルはリセットしない。

        quesionNumbers = null;
        gameCount = 0;
        correctCount = 0;
        wrongCount = 0;
        timeAttackFlag = null;
        totalQuestinCount = 0;
        lifeCount = 0;
        continueCount = 0;
        selectKey = null;
    }

    public static void AllClearList()
    {
        // メインメニューに戻ったときに各変数をリセットする関数
        // 上記に追加して、出題用テーブルもリセットする。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      

        quizTable = null;
        quesionNumbers = null;
        gameCount = 0;
        correctCount = 0;
        wrongCount = 0;
        timeAttackFlag = null;
        totalQuestinCount = 0;
        lifeCount = 0;
        continueCount = 0;
        selectKey = null;
    }

    public void OnMenuButton()
    {
        SoundMgr.instance.PlaySE(0);
        menuPanel.SetActive(true);
    }

    public void OnMenuReturnButton()
    {
        SoundMgr.instance.PlaySE(0);
        menuPanel.SetActive(false);

    }



}
