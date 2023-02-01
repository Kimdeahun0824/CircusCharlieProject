using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float PLAYER_DIR_LEFT = -1f;
    private const float PLAYER_DIR_MIDDLE = 0f;
    private const float PLAYER_DIR_RIGHT = 1f;

    private const float PLAYER_MIN_POS_X = 64f;
    private const float PLAYER_MAX_POS_X = 19136f;
    const string ANIMATOR_BOOL_IS_RUN = "IsRun";
    const string ANIMATOR_BOOL_IS_JUMP = "IsJump";
    const string ANIMATOR_TRIGGER_DIE = "Die";

    private Rigidbody2D playerRigidBody;
    private Animator playerAnimator;
    private AudioSource playerAudioSrc;
    public float speed;
    public float jumpForce;

    private bool IsJump = false;
    private bool IsDie = false;
    private bool IsGoal = false;

    private float direction;

    public void Start()
    {
        playerRigidBody = gameObject.GetComponentMust<Rigidbody2D>();
        playerAnimator = gameObject.GetComponentMust<Animator>();
        playerAudioSrc = gameObject.GetComponentMust<AudioSource>();

        direction = PLAYER_DIR_MIDDLE;
        playerAnimator.SetBool(ANIMATOR_BOOL_IS_RUN, false);

    }
    void Update()
    {
        //GameManager.Instance.currentStage++;
        if (IsGoal || IsDie)
        {
            return;
        }
        KeyMove();
        Move();
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public void KeyMove()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = PLAYER_DIR_LEFT;
            playerAnimator.SetBool(ANIMATOR_BOOL_IS_RUN, true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            direction = PLAYER_DIR_MIDDLE;
            playerAnimator.SetBool(ANIMATOR_BOOL_IS_RUN, false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = PLAYER_DIR_RIGHT;
            playerAnimator.SetBool(ANIMATOR_BOOL_IS_RUN, true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            direction = PLAYER_DIR_MIDDLE;
            playerAnimator.SetBool(ANIMATOR_BOOL_IS_RUN, false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsJump)
            {
                playerRigidBody.AddForce(Vector2.up * jumpForce);
                IsJump = true;
                playerAnimator.SetBool(ANIMATOR_BOOL_IS_JUMP, IsJump);
            }
        }
    }
    public void Move()
    {
        transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0f, 0f));
    }
    public void OnLeft_Btn_Up()
    {
        direction = PLAYER_DIR_MIDDLE;
        playerAnimator.SetBool(ANIMATOR_BOOL_IS_RUN, false);
    }
    public void OnLeft_Btn_Down()
    {
        direction = PLAYER_DIR_LEFT;
        playerAnimator.SetBool(ANIMATOR_BOOL_IS_RUN, true);
    }

    public void OnRight_Btn_Up()
    {
        direction = PLAYER_DIR_MIDDLE;
        playerAnimator.SetBool(ANIMATOR_BOOL_IS_RUN, false);
    }
    public void OnRight_Btn_Down()
    {
        direction = PLAYER_DIR_RIGHT;
        playerAnimator.SetBool(ANIMATOR_BOOL_IS_RUN, true);
    }

    public void OnJump_Btn_Click()
    {
        if (!IsJump)
        {
            playerRigidBody.AddForce(Vector2.up * jumpForce);
            IsJump = true;
            playerAnimator.SetBool(ANIMATOR_BOOL_IS_JUMP, IsJump);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Goal"))
        {
            IsGoal = true;
            playerAnimator.SetTrigger("Goal");
        }
        IsJump = false;
        playerAnimator.SetBool(ANIMATOR_BOOL_IS_JUMP, IsJump);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals(GData.OBSTACLE_TAG_NAME))
        {
            OnPlayerDie();
        }
        if (other.tag.Equals(GData.SCORE))
        {

        }
    }

    public void OnPlayerDie()
    {
        playerAnimator.SetTrigger(ANIMATOR_TRIGGER_DIE);
        IsDie = true;
    }


}
