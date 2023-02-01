using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private RectTransform myRectTransform;
    public RectTransform playerRectTransform;
    // Start is called before the first frame update
    void Start()
    {
        myRectTransform = gameObject.GetComponentMust<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
