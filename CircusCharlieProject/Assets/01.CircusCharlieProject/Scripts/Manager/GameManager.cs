using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        ScreenSetResolution();
    }

    private void ScreenSetResolution()
    {
        Screen.SetResolution(1920, 1080, true);
    }
}
