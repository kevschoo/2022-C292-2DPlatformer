using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField] int _score = 0;
    public static GameController Instance;
    [SerializeField] GameObject  _ScoreText; 
    [SerializeField] GameObject  _GameOverText; 
    [SerializeField] GameObject  _BonusEnemySpawner1; 
    [SerializeField] GameObject  _BonusEnemySpawner2; 
    [SerializeField] bool _isGameOver = false; 



    void Awake()
    {
        Instance = this;
    }

    void Start()
    {}

    void Update()
    {
        _ScoreText.GetComponent<TextMeshProUGUI>().text = "Score: "+ _score;

        if(Input.GetButtonDown("Submit") && _isGameOver)
        {
            SceneManager.LoadScene("Assets/Scenes/Level_1.unity");
        }
        CreateNewSpawner();
    }

    public void addScore(int value)
    {
        _score += value;
    }

    public int getScore()
    {
        return _score;
    }

    public void startGameOver()
    {
        _GameOverText.SetActive(true);
        _isGameOver = true;
    }

    void CreateNewSpawner()
    {
        if(GameController.Instance._score > 200)
        {
            _BonusEnemySpawner1.SetActive(true);
        }
        if(GameController.Instance._score > 400)
        {
            _BonusEnemySpawner2.SetActive(true);
        }
    }
}
