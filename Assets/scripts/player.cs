using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    private float move_speed;
    // Update is called once per frame
    void Update()
    {
        Vector3 move_to = new Vector3(move_speed * Time.deltaTime ,0f,0f);
        if (Input.GetKey(KeyCode.LeftArrow)) { transform.position -= move_to; }
        else if(Input.GetKey(KeyCode.RightArrow)){ transform.position += move_to; }
    }
}
