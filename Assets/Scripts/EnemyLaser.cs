﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    private float _speed = 8.0f;
    private bool _isEnemyLaser = false;
    [SerializeField]
    private GameObject _explosionSound;

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            Instantiate(_explosionSound, transform.position, Quaternion.identity);
            if (player != null)
            {
                player.Damage(0.5f);
            }
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject);
        }
    }
}
