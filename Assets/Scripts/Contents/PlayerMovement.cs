using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f; // 좌우 이동 속도
    [SerializeField] private float _jumpForce = 8.0f; // 점프 힘
    [SerializeField] private LayerMask _groundLayer; // 바닥체크를 위한 레이어
    [SerializeField] private int _maxJumpCount = 2;		// 땅을 밟기 전까지 할 수 있는 최대 점프 횟수
    [SerializeField] private float _normalGravityScale = 2.5f;
    
    private Rigidbody2D _rigid;
    private CapsuleCollider2D _collider;
    
    private Vector3 _footPos; // 발 위치
    private	int	_currentJumpCount = 0;	// 현재 가능한 점프 횟수
    
    public bool IsLongJump { get; set; } = false;
    public bool IsGrounded { get; private set; } = false; // 바닥체크

    public void Move(float x)
    {
        _rigid.velocity = new Vector2(x * _speed, _rigid.velocity.y);
    }

    public void Jump()
    {
        if (0 < _currentJumpCount)
        {
            _rigid.velocity = Vector2.up * _jumpForce;
            _currentJumpCount--;
        }
    }
    
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        // 바닥체크
        Bounds bounds = _collider.bounds;
        _footPos = new Vector2(bounds.center.x, bounds.min.y);
        IsGrounded = Physics2D.OverlapCircle(_footPos, 0.1f, _groundLayer);
        
        // 플레이어의 발이 땅에 닿아있고, y축 속도가 0이하이면 점프횟수 초기화
        if (IsGrounded && _rigid.velocity.y <= 0)
        {
            _currentJumpCount = _maxJumpCount;
        }
        
        // 점프 높이 조절
        if (IsLongJump && 0 < _rigid.velocity.y)
        {
            _rigid.gravityScale = 1.0f;
        }
        else
        {
            _rigid.gravityScale = _normalGravityScale;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_footPos, 0.1f);
    }
}
