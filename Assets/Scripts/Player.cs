using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    //triple shot prefab variable
    [SerializeField]
    private GameObject _tripleshotPrefab;
    [SerializeField]
    private float _firerate = 0.15f;
    private float _canfire = -1f;
   [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    //variable for isTripleShotActive - bool variable
    [SerializeField]
    private bool _isTripleShotActive = false;
 

    // Start is called before the first frame update
    void Start()
    {
       transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();//find the object. Get the component
   
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }
        
    
    }
    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        //if I hit spacekey
        //spawn GameObject (laser)
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canfire)
        {
            FireLaser();
        }
       
    }
    
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {              
            _canfire = Time.time + _firerate;
        //if tripleshotActive is True
        if (_isTripleShotActive ==true)
            {
            Instantiate(_tripleshotPrefab, transform.position, Quaternion.identity);
            }
        //else fire 1 laser
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
            }
         
    }

    public void Damage()
    {
        _lives--;

        if  (_lives < 1)
        {
            //Communicate with Spawn manager
            _spawnManager.OnPlayerDeath();
            //Let them know to stop spawning            
            Destroy(this.gameObject);
        }
    }
    
    public void TripleShotActive()
    {
        //tripleshotactive becomes true
        _isTripleShotActive = true;
        //start the power down coroutine for triple shot
        StartCoroutine(TripleShotPowerDownRoutine());            
                      

    }
    
    IEnumerator TripleShotPowerDownRoutine()
        {
        //wait 5 seconds
        yield return new WaitForSeconds(5.0f);
        //set the triple shot to false
        _isTripleShotActive = false;
        }
    
    



}



