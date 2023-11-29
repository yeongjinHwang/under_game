using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{    
    private Rigidbody2D rigid;
    private Animator animator;
    private bool isJump;
    private float moveSpeed = 4f, jumpForce = 4f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        if (horizontalInput != 0)
        {
            bool rightFlag = horizontalInput > 0;
            animator.SetBool("right", rightFlag); 
            animator.SetBool("left", !rightFlag); 
        }

        Vector2 moveVector = new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0f);
        transform.Translate(moveVector);
    }

    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = true; 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")){ isJump = false; } // 바닥 충돌 감지

        if (collision.gameObject.CompareTag("portal")){ SceneManager.LoadScene("stage_select_scene"); } // 해당 장면으로 이동 
    }
}