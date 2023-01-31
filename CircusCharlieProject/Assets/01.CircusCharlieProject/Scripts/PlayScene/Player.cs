using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const string IS_RUN = "IsRun";
    private Rigidbody2D playerRigidBody;
    private Animator playerAnimator;
    public float speed;
    public float jumpForce;

    private bool IsJump = false;

    public void Start()
    {
        playerRigidBody = gameObject.GetComponentMust<Rigidbody2D>();
        playerAnimator = gameObject.GetComponentMust<Animator>();
    }

    public void OnLeft_Btn_Click()
    {

    }

    public void OnRight_Btn_Click()
    {

    }

    public void OnJump_Btn_Click()
    {
        if(!IsJump)
        {
            playerRigidBody.AddForce(Vector2.up * jumpForce);
            IsJump = true;
        }
    }

    public void OnCollisionEnter2D()
    {
        
    }


}
