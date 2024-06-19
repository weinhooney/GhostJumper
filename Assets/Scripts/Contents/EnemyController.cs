using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 _moveDir;
    private Vector3 MoveDir
    {
        get { return _moveDir;}
        set
        {
            _moveDir = value;
            float scale = 0 < _moveDir.x ? -1f : 1f;
            transform.localScale = new Vector3(scale, 1, 1);
        }
    }

    private void Awake()
    {
         MoveDir = Quaternion.Euler(0, 0, UnityEngine.Random.Range(-80f, 80f)) * Vector2.down;
    }

    private void Update()
    {
        transform.position += MoveDir * 5 * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.NameToLayer("Ground") == other.gameObject.layer || LayerMask.NameToLayer("Wall") == other.gameObject.layer)
        {
            MoveDir = Vector3.Reflect(MoveDir, other.transform.up);
        }
    }
}
