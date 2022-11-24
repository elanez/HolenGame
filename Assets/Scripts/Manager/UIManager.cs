using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private UIController _controller;
    private void Awake() 
    {
        instance = this;
    }

    private void Start()
    {
        SetupEvent();
    }

    private void StartMatch()
    {
        _controller.ActivateHUD(true);
        UpdateRound(1);
    }

    private void EndMatch()
    {
        _controller.ActivateHUD(false);
        SetupWinner();
        _controller.ActivateEndGamePanel(true);
    }

    private void UpdatePlayerName()
    {
        Player player = DataManager.instance.GetActivePlayer();
        _controller.UpdatePlayerName(player.name);
        _controller.ActivateObserveText(false);
    }

    public void UpdateScore()
    {
        Player player = DataManager.instance.GetActivePlayer();
        _controller.UpdatePlayerScore(player.Score);
    }

    public void ShowObserveText()
    {
        _controller.ActivateObserveText(true);
    }

    public void UpdateRound(int num)
    {
        _controller.UpdateRound(num);
    }

    private void SetupWinner()
    {
        Player player = DataManager.instance.GetWinner();
        if(player == null)
            _controller.SetTieGame();
        else
            _controller.SetWinner(player.name);
    }

    private void SetupEvent()
    {
        EventManager.instance.OnStartTurn += UpdatePlayerName;
        EventManager.instance.OnStartTurn += UpdateScore;
        EventManager.instance.OnGameObserve += ShowObserveText;
        EventManager.instance.OnGameEnd += EndMatch;
    }

    
}
