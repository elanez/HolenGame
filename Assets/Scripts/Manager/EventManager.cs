using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    public delegate void StartMatch();
    public event StartMatch OnStartMatch;
    public delegate void TurnAction();
    public event TurnAction OnStartTurn;
    public delegate void ObserveState();
    public event ObserveState OnGameObserve;

    public delegate void ScoreAction();
    public event ScoreAction OnPlayerScored;
    public delegate void GameEndState();
    public event GameEndState OnGameEnd;

    private void Awake() 
    {
        instance = this;
    }

    public void InvokeMatch()
    {
        Debug.Log("EVENT: Start Match");
        OnStartMatch?.Invoke();
    }

    public void InvokeTurn()
    {
        Debug.Log("EVENT: Turn State");
        Debug.Log("EVENT: " + DataManager.instance.GetActivePlayer().name + " is playing");
        OnStartTurn?.Invoke();
    }

    public void InvokeObserve()
    {
        Debug.Log("EVENT: Observe State");
        OnGameObserve?.Invoke();
    }

    public void InvokeScore()
    {
        Debug.Log("EVENT: Player scored");
        OnPlayerScored?.Invoke();
    }
    public void InvokeGameEnd()
    {
        Debug.Log("EVENT: End of Game");
        OnGameEnd?.Invoke();
    }
}
