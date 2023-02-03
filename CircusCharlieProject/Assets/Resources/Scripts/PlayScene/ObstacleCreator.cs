using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    //일정 시간마다 특정 좌표 + 몇에 장애물을 생성
    private float delay;
    public int minDelay;
    public int maxDelay;

    public float obstacleY;

    public void Start()
    {
        GFunc.Log($"obstacleCreator Test : {gameObject.name}");
        StartCoroutine("ObstacleCreate");
    }

    IEnumerator ObstacleCreate()
    {
        while (true)
        {
            if (GameManager.Instance.player_Is_Goal || GameManager.Instance.player_Is_Die) break;
            delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            GameObject obstacle = ObjectPoolingManager.Instance.obstaclePop();
            obstacle.transform.localPosition = new Vector3(GameManager.Instance.cameraPosition.x + 3000f, obstacleY, 0f);
            obstacle.SetActive(true);
        }

    }
}
