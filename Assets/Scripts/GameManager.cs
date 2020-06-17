﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    int _score;
    int _lives;

    public int maxLives;

    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {

        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "TitleScreen")
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                SceneManager.LoadScene("TitleScreen");
            }
            else if (SceneManager.GetActiveScene().name == "GameOver")
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Return()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
    }

    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            Debug.Log("Score is changed to " + _score);
        }
    }

    public int lives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            if (_lives > maxLives)
                _lives = maxLives;
            else if (_lives < 0)
                SceneManager.LoadScene("GameOver");

            Debug.Log("Lives is changed to " + _lives);
        }
    }
}
