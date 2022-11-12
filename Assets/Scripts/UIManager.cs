using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //handle to text
    [SerializeField]
    private Text _scoreText;
    private GameObject _player;
    
    // Start is called before the first frame update
    void Start()
    {
        //assign text component to handle
        _scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //figure out method to update score

    public void UpdateScore(int playerscore)
    {
       // _player = GameObject.Find("Player").GetComponent<Player>();
        // if (_player != null)
          //  {
                _scoreText.text = "Score: " + playerscore;
            //}
        

    }


}
