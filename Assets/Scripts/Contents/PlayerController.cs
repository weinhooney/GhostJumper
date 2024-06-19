using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {   
        // 좌우이동
        float x = Input.GetAxisRaw("Horizontal");
        _movement.Move(x);
        
        // 점프키를 누르면 점프
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _movement.Jump();
        }
        
        if (Input.GetKey(KeyCode.Space)) // 점프키를 누르고 있으면 LONG 점프
        {
            _movement.IsLongJump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space)) // 점프키를 떼면 LONG 점프 취소
        {
            _movement.IsLongJump = false;
        }
    }
}
