using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const string IS_RUN = "IsRun";
    const string IS_JUMP = "IsJump";

    private Rigidbody2D playerRigidBody;
    private Animator playerAnimator;
    private AudioSource playerAudioSrc;
    public float speed;
    public float jumpForce;

    private bool IsJump = false;

    public void Start()
    {
        playerRigidBody = gameObject.GetComponentMust<Rigidbody2D>();
        playerAnimator = gameObject.GetComponentMust<Animator>();
        playerAudioSrc = gameObject.GetComponentMust<AudioSource>();

        playerAnimator.SetBool(IS_RUN, true);
    }

    public void OnLeft_Btn_Click()
    {

    }

    public void OnRight_Btn_Click()
    {

    }

    public void OnJump_Btn_Click()
    {
        if (!IsJump)
        {
            playerRigidBody.AddForce(Vector2.up * jumpForce);
            IsJump = true;
            playerAnimator.SetBool(IS_JUMP, IsJump);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GFunc.Log("Collsion Test");
        IsJump = false;
        playerAnimator.SetBool(IS_JUMP, IsJump);
    }


}
