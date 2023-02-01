using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Start : MonoBehaviour
{
    public void OnStartBtnClick()
    {
        GameManager.Instance.currentStage = 1;
        GFunc.LoadScene(GData.SCENE_NAME_PLAY);
    }
}
