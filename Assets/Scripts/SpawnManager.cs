using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    IEnumerator SpawnRoutine()
    {       
                //while loop (infinite loop) 
        while (_stopSpawning == false)
        {                  
            //position object spawns at
            Vector3 posToSpawn = new Vector3(Random.Range(-8f,8f),7,0);
            //Instantiate enemy prefab
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            //yield wait for 5 seconds
            yield return new WaitForSeconds(5.0f);
        }
        //never get here - infinite loop

    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;

    }


}
