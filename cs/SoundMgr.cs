using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); 
        }
    }

    public AudioSource audioSourceSE; //SEのスピーカー(0:BUTTON,1:READY,2:CORRECT, 3:WRONG, 4:VERYLOW, 5:ROW, 6:HALF, 7:CLEAR)
    public AudioClip[] audioClip; // SEの音源

    public void PlaySE(int select)
    {
        audioSourceSE.PlayOneShot(audioClip[select]); //SEを一度だけ鳴らす

    }
}
