using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : SingletonBase<ObjectPoolingManager>
{
    private Stack<GameObject> obstaclePool;
    public GameObject stage_1_Obj;
    public GameObject stage_2_Obj;
    public Transform objParent;
    public int objPoolCreateCount;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        obstaclePool = new Stack<GameObject>();


    }

    public void PoolInit()
    {

        for (int i = 0; i < objPoolCreateCount; i++)
        {
            GameObject tempObj = Instantiate(stage_1_Obj);
            tempObj.transform.parent = this.transform;
            tempObj.transform.localPosition = Vector3.zero;
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
