using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Start : MonoBehaviour
{
    public void OnStartBtnClick()
    {
        GFunc.LoadScene(GData.SCENE_NAME_PLAY);
    }
}
