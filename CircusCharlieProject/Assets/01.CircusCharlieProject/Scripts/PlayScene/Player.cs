using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float speed;
    public float jumpForce;

    public void Start()
    {
        playerRigidBody = gameObject.GetComponentMust<Rigidbody2D>();
    }

    public void OnLeft_Btn_Click()
    {

    }

    public void OnRight_Btn_Click()
    {

    }

    public void OnJump_Btn_Click()
    {
        playerRigidBody.AddForce(Vector2.up * jumpForce);
    }
}
