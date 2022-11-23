using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public delegate void ScoreAction();
    public event ScoreAction OnPlayerScored;

    public delegate void ObserveAction();
    
    public event ObserveAction OnPlayerObserve;


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
        OnPlayerObserve?.Invoke();
    }
}
