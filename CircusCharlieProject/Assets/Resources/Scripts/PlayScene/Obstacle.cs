using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //생성되면 왼쪽으로 움직임
    //카메라의 좌표 x보다 작아지면 (카메라 왼쪽으로 나가면) 풀에 다시 넣어줌
    public float speed;
    public void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        if ((transform.localPosition.x < GameManager.Instance.cameraPosition.x) || (GameManager.Instance.player_Is_Die || GameManager.Instance.player_Is_Goal))
        {
            ObjectPoolingManager.Instance.obstaclePush(gameObject);
        }
    }
}
