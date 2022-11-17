using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField]
    private float _speed = 3.5f;
    private float _speedMultiplier = 2;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleshotPrefab;
    [SerializeField]
    private float _firerate = 0.15f;
    private float _canfire = -1f;
   [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    private UIManager _uiManager;
    [SerializeField]
    private GameObject _shieldVisual;
    

    private bool _isTripleShotActive = false;    
    private bool _isSpeedBoostActive = false;
    private bool _isShieldActive = false;

    [SerializeField]
    private int _score;
        
    
   
 
    
    void Start()
    {
       transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();//find the object. Get the component
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }   
        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL");
        }
    }
    
    void Update()
    {
        CalculateMovement();
            
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
       
        if (_isTripleShotActive ==true)
            {
            Instantiate(_tripleshotPrefab, transform.position, Quaternion.identity);
            }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
            }      
    }

    public void Damage()
    {        
        if (_isShieldActive == true)
        {            
            _isShieldActive = false;
            _shieldVisual.SetActive(false);
            return;
        }     
     
        _lives--;
        //calls UpdateLives from UIManager
        _uiManager.UpdateLives(_lives);

        if  (_lives < 1)
        {           
            _spawnManager.OnPlayerDeath();                       
            Destroy(this.gameObject);            
        }
    }
    
    public void TripleShotActive()
    {        
        _isTripleShotActive = true;        
        StartCoroutine(TripleShotPowerDownRoutine());     
    }
    
    IEnumerator TripleShotPowerDownRoutine()
        {         
        yield return new WaitForSeconds(5.0f);         
        _isTripleShotActive = false;
        }
    
    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostPowerDownRoutine());        
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        _speed /= _speedMultiplier;
    }

    public void ShieldActive()
    {
        _isShieldActive = true;
        //enable Shield Visualizer
        _shieldVisual.SetActive(true);       
    }

    //add method to add 10 the score
    //communicate with the UI to update score
   public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }



}



