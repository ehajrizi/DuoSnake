using System.Collections;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action gameStarted;

    bool isPlaying = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        StartGame();
    }

    public void StartGame()
    {
        isPlaying = true;
        gameStarted?.Invoke();
    }
}
