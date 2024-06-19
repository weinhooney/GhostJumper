using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 _dir;
    private void Awake()
    {
         _dir = Quaternion.Euler(0, 0, -45) * Vector2.down;
    }

    private void Update()
    {
        transform.position += _dir * 5 * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.NameToLayer("Ground") == other.gameObject.layer || LayerMask.NameToLayer("Wall") == other.gameObject.layer)
        {
            _dir = Vector3.Reflect(_dir, other.transform.up);
        }
    }
}
