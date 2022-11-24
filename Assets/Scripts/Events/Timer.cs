using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timer;
    [SerializeField]
    private float _turnDuration;
    [SerializeField]
    private float _observeDuration;
    private float _elapsedTime;


    private void Start()
    {
        // EventManager.instance.OnStartTurn += ShowTimer;
        EventManager.instance.OnStartTurn += RestartTurnTimer;
        EventManager.instance.OnGameObserve += RestartObserveTimer;
    }

    private void Update()
    {
        if(GameManager.instance.GetState() != GameState.TURN 
            && GameManager.instance.GetState() != GameState.OBSERVE)
            return;

        _elapsedTime -= Time.deltaTime;
        _timer.SetText(_elapsedTime.ToString("0"));
        if(_elapsedTime <= 0)
        {
            EventManager.instance.InvokeTurn();
        }
    }

    private void RestartTurnTimer()
    {
        _elapsedTime = _turnDuration;
    }

    private void RestartObserveTimer()
    {
        _elapsedTime = _observeDuration;
    }

    private void ShowTimer()
    {
        _timer.enabled = true;
    }

    private void HideTimer()
    {
        _timer.enabled = false;
    }

}
