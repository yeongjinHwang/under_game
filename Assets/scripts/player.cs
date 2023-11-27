using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // 장면 관리를 위해 필요

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float move_speed; // 좌우 속도
    private float jump_force; // 점프 힘
    // Update is called once per frame
    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // player 이동
        Vector3 move_to = new Vector3(move_speed * Time.deltaTime ,0f,0f);
        if (Input.GetKey(KeyCode.LeftArrow)) { transform.position -= move_to; }
        if(Input.GetKey(KeyCode.RightArrow)){ transform.position += move_to; }
        if(Input.GetKey(KeyCode.Space)){ rb.velocity = Vector2.up * jump_force;  }

        // start flag아래로 떨어져서 다음 scene으로 이동
        if(transform.position.y < -5){
            Debug.Log("start_scene -> stage_scene");
            SceneManager.LoadScene("stage_scene"); // 해당 장면으로 이동
        }
    }
    private void FixedUpdate() {
        float horizon = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizon * 3, rb.velocity.y);
    }
}
