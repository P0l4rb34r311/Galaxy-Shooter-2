﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    private float _speed = 8.0f;
    private bool _isEnemyLaser = false;

    void Update()
    {
        MoveDown();

    }
    void MoveDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);


        if (transform.position.y < -7f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }        

    }

    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;        
        Debug.Log("Enemy laser detected");
    }
}