using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotatespeed = 3.0f;
    [SerializeField]
    private GameObject _explosionPrefab;
    private SpawnManager _spawnManager;

    
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate object on zed axis (3 m/s?)
        transform.Rotate(Vector3.forward * _rotatespeed * Time.deltaTime);        
    }

    //check for Laser collision (Trigger)    

        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Laser")
        {            
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            //Triggers StartSpawning method in Spawn Method_
            _spawnManager.StartSpawning();            
            Destroy(this.gameObject,0.25f);            
        }    
          
    }

    


}
