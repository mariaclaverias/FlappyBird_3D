using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private bool isGameStart = false;

    public static Action onStartGame;
    public static Action onEndGame;

    private void Update()
    {
        if (!isGameStart && !player.IsDead)
        {
            StartGame();
        }
        else if (isGameStart && player.IsDead)
        {
            EndGame();
        }
    }

    private void StartGame()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                onStartGame?.Invoke();
                isGameStart = true;
            }
        }
    }

    private void EndGame()
    {
        onEndGame?.Invoke();
        isGameStart = false;
    }
}
