using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    public delegate void ScoreAction();
    public event ScoreAction OnPlayerScored;

    public delegate void ObserveAction();
    public event ObserveAction OnGameObserve;

    public delegate void GameEndAction();
    public event GameEndAction OnGameEnd;

    private void Awake() 
    {
        instance = this;
    }

    public void InvokeScore()
    {
        OnPlayerScored?.Invoke();
    }

    public void InvokeObserve()
    {
        Debug.Log("Game State: Observe");
        OnGameObserve?.Invoke();
    }

    public void InvokeGameEnd()
    {
        Debug.Log("Game State: End");
        OnGameEnd?.Invoke();
    }
}
