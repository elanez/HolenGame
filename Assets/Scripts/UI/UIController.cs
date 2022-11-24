using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField]
    private Canvas _hudPanel;
    [SerializeField]
    private Canvas _endGamePanel;

    [Header("HUD")]
    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private TextMeshProUGUI _score;
    [SerializeField]
    private TextMeshProUGUI _round;
    [SerializeField]
    private TextMeshProUGUI _timer;
    [SerializeField]
    private TextMeshProUGUI _observe;

    [Header("End Game")]
    [SerializeField]
    private TextMeshProUGUI _winnerText;
    [SerializeField]
    private TextMeshProUGUI _tieText;
    [SerializeField]
    private TextMeshProUGUI _winnerName;

    #region in game

    public void ActivateHUD(bool activate)
    {
        _hudPanel.enabled = activate;
    }

    public void ActivateObserveText(bool activate)
    {
        _observe.enabled = activate;
    }

    public void UpdateRound(int number)
    {
        _round.SetText(number.ToString());
    }

    public void UpdatePlayerName(string name)
    {
        _name.SetText(name);
    }

    public void UpdatePlayerScore(int score)
    {
        _score.SetText(score.ToString());
    }

    #endregion

    #region end game

    public void ActivateEndGamePanel(bool activate)
    {
        _endGamePanel.enabled = activate;
    }

    public void SetWinner(string name)
    {
        _winnerText.enabled = true;
        _winnerName.SetText(name);
    }

    public void SetTieGame()
    {
        _winnerText.enabled = false;
        _winnerName.enabled = false;
        _tieText.enabled = true;
    }

    #endregion 
}
