using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    public int currentStage;
    public void Start()
    {
        ScreenSetResolution();
        currentStage = 0;
    }

    private void ScreenSetResolution()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void OnExitBtnClick()
    {
        GFunc.QuitThisGame();
    }

    public void OnStartBtnClick()
    {
        GFunc.LoadScene(GData.SCENE_NAME_PLAY);
    }

}
