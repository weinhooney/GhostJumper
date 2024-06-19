using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _movement;
    private HashSet<GameObject> _jumpEnemies = new HashSet<GameObject>();

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
        
        // 적을 뛰어 넘었는지 체크
        // Debug.DrawRay(transform.position, Vector2.down, Color.red );
        
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, 100, LayerMask.GetMask("Enemy"));
        for (int i = 0; i < hits.Length; ++i)
        {
            if (false == _jumpEnemies.Contains(hits[i].collider.gameObject))
            {
                _jumpEnemies.Add((hits[i].collider.gameObject));
            }            
        }
        
        // 바닥에 닿았을 때 뛰어 넘은 적들이 있으면 제거
        if (_movement.IsGrounded && 0 < _jumpEnemies.Count)
        {
            foreach (var enemy in _jumpEnemies)
            {
                enemy.SetActive(false);
            }
            _jumpEnemies.Clear();
        }
    }
}
