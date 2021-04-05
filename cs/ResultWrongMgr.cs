using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultWrongMgr : MonoBehaviour
{
    public GameObject returnPanel;
    public GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        SoundMgr.instance.PlaySE(3);
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

    public void OnMenuButton()
    {
        menuPanel.SetActive(true);
        SoundMgr.instance.PlaySE(0);

    }

    public void OnMenuReturnButton()
    {
        menuPanel.SetActive(false);
        SoundMgr.instance.PlaySE(0);

    }
}
