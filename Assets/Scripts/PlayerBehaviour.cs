using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody playerRigid;
    private Animator animator;
    private bool onGround;
    private float minJumpforce;
    private float maxJumpforce;
    private float jumpforce;
    private bool chargedJumping;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        chargedJumping = false;
        onGround = true;
        jumpforce = 0f;
        minJumpforce = 5f;
        maxJumpforce = 20f;
        playerRigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        outOfBound();
        float xMove = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        float zMove = Input.GetAxis("Vertical")*Time.deltaTime*speed;
        Debug.Log("APANHOU O POWER-UP: " + chargedJumping);
        float moveChecker = xMove + zMove;

        transform.Translate(xMove,0f,zMove);

        if(moveChecker != 0)
        {
            animator.SetBool("hasStopped", false);
        } else
        {
            animator.SetBool("hasStopped", true);
        }
        
        animator.SetFloat("walkingSpeed", (moveChecker >= 0 ? moveChecker : - moveChecker));

        if(onGround)
        {
            if(Input.GetButton("Jump"))
            {
                if (chargedJumping)
                {
                    jumpforce = (jumpforce <= maxJumpforce) ? jumpforce + Time.deltaTime * 10f : maxJumpforce;
                    animator.SetFloat("jumpforce", jumpforce + minJumpforce);
                } else
                {
                    jumpforce = 0.1f;
                }
            } else
            {
                if(jumpforce > 0f)
                {
                    jumpforce = jumpforce + minJumpforce;
                    playerRigid.velocity = new Vector3(jumpforce / 10f, jumpforce, 0f);
                    jumpforce = 0f;
                    animator.SetFloat("jumpforce", jumpforce);
                    onGround = false;
                    animator.SetBool("onGround", false);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            onGround = true;
            animator.SetBool("onGround", true);
        }
    }

    private void outOfBound()
    {
        if(this.transform.position.y < 20)
        {
            this.transform.position = new Vector3(0, 28, 0);
            FindObjectOfType<GameBehaviour>().takeDamage(25);
        }
    }
    
    public void jumpingPowerUp()
    {
        chargedJumping = true;
    }

    public bool hasJumpPowerUp()
    {
        return chargedJumping;
    }

    /*private void PlayerMovement()
    {
        transform.Translate(playerMovesInputH, 0, playerMovesInputV);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }*/
}
