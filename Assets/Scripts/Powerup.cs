using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private AudioClip _clip;
    [SerializeField] //0 = Triple Shot, 1 = Speed, 2 = Shield
    private int powerupID;
               

    // Update is called once per frame
    void Update()
    {
        //move down at a speed of 3 (adjust in Inspector)
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        //when leave screen, destroy this object
        if (transform.position.y <= -4.7f)
        {
            Destroy(this.gameObject);
        }
    }

    //OnTriggerCollision
    //Only be collectable by the Player (Hint: Use Tags)
    //on collected, destroy

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_clip, transform.position);
            //communicate with the player script
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch (powerupID) //switching through powerupID variable
                {
                    case 0:
                        player.TripleShotActive();
                        //_audioSource.Play();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldActive();
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;
                }
               
            }
                Destroy(this.gameObject);
        }
    }
}
    

    //drop object to prefab folder


