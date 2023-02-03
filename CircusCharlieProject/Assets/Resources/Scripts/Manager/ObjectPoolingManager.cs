using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObjectPoolingManager : SingletonBase<ObjectPoolingManager>
{
    private Stack<GameObject> obstaclePool;
    public GameObject objParent;
    public GameObject obstacleObj;
    public int objPoolCreateCount;

    new void Awake()
    {
        base.Awake();

        SceneManager.sceneLoaded += OnSceneLoaded;

        GameObject rootObj = GFunc.GetRootObj(GData.ROOT_GAME_OBJS);
        objParent = GFunc.FindChildObj(rootObj, "WorldObjs");
        objParent = GFunc.FindChildObj(objParent, "Obstacles");
        obstacleObj = GFunc.FindChildObj(objParent, "Obstacle_FireRing");

        obstaclePool = new Stack<GameObject>();

        PoolInit();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals(GData.PLAY_STAGE1_SCENE_NAME))
        {

        }
        if (scene.name.Equals(GData.PLAY_STAGE2_SCENE_NAME))
        {
            obstaclePool.Clear();
            ObstacleObjChange();
            PoolInit();
        }

    }

    public void ObstacleObjChange()
    {
        GameObject rootObj = GFunc.GetRootObj(GData.ROOT_GAME_OBJS);
        objParent = GFunc.FindChildObj(rootObj, "WorldObjs");
        objParent = GFunc.FindChildObj(objParent, "Obstacles");
        obstacleObj = GFunc.FindChildObj(objParent, "Obstacle_Monkey");

    }


    public void PoolInit()
    {
        for (int i = 0; i < objPoolCreateCount; i++)
        {
            GameObject tempObj = Instantiate(obstacleObj, Vector3.zero, Quaternion.identity, objParent.transform);
            tempObj.SetActive(false);
            obstaclePool.Push(tempObj);
            tempObj = null;
        }
    }

    public GameObject obstaclePop()
    {
        return obstaclePool.Pop();
    }

    public void obstaclePush(GameObject obj_)
    {
        obj_.transform.localPosition = Vector3.zero;
        obj_.SetActive(false);
        obstaclePool.Push(obj_);
    }

}
