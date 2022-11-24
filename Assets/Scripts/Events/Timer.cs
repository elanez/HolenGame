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
    private bool _isRunning;


    private void Start()
    {
        // EventManager.instance.OnStartTurn += ShowTimer;
        EventManager.instance.OnStartTurn += RestartTurnTimer;
        EventManager.instance.OnGameObserve += RestartObserveTimer;
    }

    private void Update()
    {
        if(!_isRunning)
            return;

        _elapsedTime -= Time.deltaTime;
        _timer.SetText(_elapsedTime.ToString("0"));
        if(_elapsedTime <= 0)
        {
            Debug.Log("TIMER: INVOKE TURN");
            _isRunning = false;
            GameManager.instance.Turn();
        }
    }

    private void RestartTurnTimer()
    {
        _elapsedTime = _turnDuration;
        _isRunning = true;
    }

    private void RestartObserveTimer()
    {
        _isRunning = true;
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
