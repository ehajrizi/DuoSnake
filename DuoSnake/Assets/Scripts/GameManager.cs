using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    //reference me thirre me lehte prej komponenteve tjera
    public static GameManager instance;

    public event Action gameStarted, scoreIncremented, gameLost;

    bool isPlaying = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (!isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isPlaying = true;
                StartGame();
            }
        }
    }

    //? - not null
    public void StartGame()
    {
        gameStarted?.Invoke();
        Debug.Log("GAme has started!");
    }

    public void LoseGame()
    {
        isPlaying = false;
        gameLost?.Invoke();
    }

    public void IncrementScore()
    {
        scoreIncremented?.Invoke();
    }
}
