using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _speed = 4.0f;
    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }


    void Update()
    {        
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -4.7f) 
        {
            float randomX = (Random.Range(-9.4f, 9.4f));    
            transform.position = new Vector3(randomX, 7f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {            
           Player player = other.transform.GetComponent<Player>();
           if (player != null)
           {
              player.Damage();
           }            
            Destroy(this.gameObject);           
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            //Add 10 to score (access player data to add score)
            if (_player != null)
            {
                _player.AddScore(10);
            }
            Destroy(this.gameObject);
            
        }

    }
}
