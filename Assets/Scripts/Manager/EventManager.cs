using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public delegate void ScoreAction();
    public event ScoreAction OnPlayerScored;

    private void Awake() 
    {
        instance = this;
    }

    public void InvokeScore()
    {
        if(OnPlayerScored != null)
            OnPlayerScored();
    }
}
