using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // 장면 관리를 위해 필요

public class player : MonoBehaviour
{    
    private Rigidbody2D rigid;
    private Animator animator;
    private bool isJump;
    private float move_speed = 4, jump_force = 4; // 좌우 속도 및 점프력
    void Start(){
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        move();
        jump();
    }
    private void move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0){ 
            animator.SetBool("right",true); 
            animator.SetBool("left",false); 
        }
        else if (horizontalInput < 0){ 
            animator.SetBool("right",false); 
            animator.SetBool("left",true); 
        }
        Vector3 move_to = new Vector3(horizontalInput * move_speed * Time.deltaTime, 0f, 0f);
        transform.Translate(move_to);
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rigid.AddForce(Vector3.up * jump_force, ForceMode2D.Impulse);
            isJump = true; 
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Debug.Log("충돌 감지: " + collision.gameObject.tag);
            isJump = false;
        }
        if (collision.gameObject.CompareTag("portal")){
            Debug.Log("start_scene -> stage_select");
            SceneManager.LoadScene("stage_select_scene"); // 해당 장면으로 이동
        }
    }
}
