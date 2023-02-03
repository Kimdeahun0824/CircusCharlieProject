using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : SingletonBase<GameManager>
{
    public int Score;
    public int currentStage;

    public Vector3 cameraPosition;
    public float cameraWidth;

    public TMP_Text stageText;
    public TMP_Text scoreText;

    public GameObject parentObj;

    public bool player_Is_Goal;
    public bool player_Is_Die;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GFunc.Log($"OnSceneLoaded : {scene.name}");
        player_Is_Goal = false;
        player_Is_Die = false;
        if (scene.name.Equals(GData.PLAY_STAGE1_SCENE_NAME))
        {
            FindUiBoard();
            StageTextChange();
            ScoreTextChange();
        }
        if (scene.name.Equals(GData.PLAY_STAGE2_SCENE_NAME))
        {
            FindUiBoard();
            StageTextChange();
            ScoreTextChange();
        }
        if (scene.name.Equals("00.InitScene"))
        {
            GFunc.LoadScene(GData.TITLE_SCENE_NAME);
        }

    }

    public void FindUiBoard()
    {
        GFunc.Log($"OnSceneLoaded Test");
        parentObj = GFunc.GetRootObj("UIObjs");
        parentObj = parentObj.FindChildObj("Board");
        stageText = parentObj.FindChildObj("StageText").GetComponent<TMP_Text>();
        scoreText = parentObj.FindChildObj("ScoreText").GetComponent<TMP_Text>();
    }

    public void StageTextChange()
    {
        stageText.text = "Stage : " + currentStage;
    }

    public void ScoreTextChange()
    {
        scoreText.text = "Score : " + Score;
    }

    public void GameRestart()
    {
        StartCoroutine(CoroutinesGameRestart());
    }
    IEnumerator CoroutinesGameRestart()
    {
        yield return new WaitForSeconds(2f);
        GFunc.LoadScene(GData.TITLE_SCENE_NAME);
    }
    public new void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
        ScreenSetResolution();
        currentStage = 0;
    }

    public void Start()
    {

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
        GFunc.LoadScene(GData.PLAY_STAGE1_SCENE_NAME);
    }

    public void StageClear()
    {
        StartCoroutine(NextStage());
    }

    IEnumerator NextStage()
    {
        yield return new WaitForSeconds(1f);
        currentStage++;
        GFunc.LoadScene(GData.PLAY_STAGE2_SCENE_NAME);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GFunc.QuitThisGame();
        }
    }

}