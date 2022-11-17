using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    //handle to text
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameoverText;
    [SerializeField]
    private Text _restartText;
    //Reference to Sprite being swapped, actual onscreen display
    [SerializeField]
    private Image _LivesImg; //image component handle
    //maintain reference to sprites working with
    [SerializeField]
    private Sprite[] _liveSprites;

    private GameManager _gameManager; 


    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameoverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        if (_gameManager == null)
        {
            Debug.LogError("Game Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void UpdateScore(int playerscore)
    {
        _scoreText.text = "Score: " + playerscore;
    }

    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite = _liveSprites[currentLives];
        if (currentLives == 0)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        _gameManager.GameOver();
        StartCoroutine(FlickerText());
        _restartText.gameObject.SetActive(true);
    }

    IEnumerator FlickerText()
    {
        while (true)
        {
            _gameoverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _gameoverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}





       