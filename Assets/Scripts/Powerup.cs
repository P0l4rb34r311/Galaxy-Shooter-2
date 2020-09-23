﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    [SerializeField] // 0 = TripleShot, 1 = Speed, 2 = Shield 
    private int _powerupID;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        
        if(transform.position.y < -5.8f)
        {
            Destroy(this.gameObject);
        }
                
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                
                switch(_powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        Debug.Log("Collected Shields");
                        break;

                }
                
            }
            Destroy(this.gameObject);
        }
    }

}