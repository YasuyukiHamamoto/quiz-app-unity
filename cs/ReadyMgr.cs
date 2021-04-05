using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyMgr : MonoBehaviour
{
    public GameObject attentionImage;

    // Start is called before the first frame update
    void Start()
    {
        SoundMgr.instance.PlaySE(1);
        SetAttentionImage();
    }

    public void SetAttentionImage()
    {
        if (QuizMgr.IsTimeAttackFlag())
        {
            attentionImage.SetActive(true);
        }
        else
        {
            attentionImage.SetActive(false);
        }
    }

}
