using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public delegate void ScoreAction();
    public delegate void ObserveAction();
    public event ScoreAction OnPlayerScored;
    public event ObserveAction OnPlayerObserve;

    private void Awake() 
    {
        instance = this;
    }

    public void InvokeScore()
    {
        if(OnPlayerScored != null)
            OnPlayerScored();
    }

    public void InvokeObserve()
    {
        if(OnPlayerObserve != null)
            OnPlayerObserve();
    }
}
