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
    [SerializeField] bool _isGameOver = false; 



    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _ScoreText.GetComponent<TextMeshProUGUI>().text = "Score: "+ _score;

        if(Input.GetButtonDown("Submit") && _isGameOver)
        {
            SceneManager.LoadScene("Assets/Levels/Level_1.unity");
        }
    }

    public void addScore(int value)
    {
        _score += value;
    }

    public void startGameOver()
    {
        _GameOverText.SetActive(true);
        _isGameOver = true;
    }

}
