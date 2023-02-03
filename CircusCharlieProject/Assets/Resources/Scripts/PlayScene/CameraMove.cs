using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private const float MAP_MIN_SIZE_X = 0f;
    private const float MAP_MAX_SIZE_X = 17280f;
    private RectTransform myRectTransform;
    public RectTransform playerRectTransform;
    private float targetPositionX;
    // Start is called before the first frame update
    void Start()
    {
        myRectTransform = gameObject.GetComponentMust<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPositionX = Mathf.Clamp(playerRectTransform.localPosition.x, MAP_MIN_SIZE_X, MAP_MAX_SIZE_X);
        myRectTransform.localPosition = new Vector3(targetPositionX, 0f, -100f);

        GameManager.Instance.cameraPosition = transform.localPosition;
    }
}
