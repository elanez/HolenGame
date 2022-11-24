using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header("Players")]
    public List<Player> playerList = new List<Player>();

    private int _activePlayerIndex;

    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        EventManager.instance.OnPlayerScored += AddScore;
    }

    public void SetupPlayers()
    {
        foreach (Player player in playerList)
            player.Score = 0;
        _activePlayerIndex = 0;
    }

    public void AddScore()
    {
        Debug.Log(playerList[_activePlayerIndex].name + " has scored!");
        playerList[_activePlayerIndex].Score++;
        Debug.Log(playerList[_activePlayerIndex].name + " score: " + playerList[_activePlayerIndex].Score);
    }

    public Player GetActivePlayer()
    {
        Debug.Log("Player " + playerList[_activePlayerIndex].name + " is active");
        return playerList[_activePlayerIndex];
    }

    public bool NextTurn()
    {
        Debug.Log("Next Turn");
        _activePlayerIndex++;
        if(_activePlayerIndex >= playerList.Count)
        {
            _activePlayerIndex = 0;
            return false;
        }
        else
            return true;
    }

    public Player GetWinner()
    {
        int highScoreIndex = 0;
        int highScore = playerList[0].Score;
        bool isTie = false;

        for(int i = 1; i < playerList.Count; i++)
        {
            if(highScore < playerList[i].Score)
            {
                highScore = playerList[i].Score;
                highScoreIndex = i;
                isTie = false;
            }
            else if(highScore == playerList[i].Score)
                isTie = true;
        }

        if(isTie)
            return null;
        else
            return playerList[highScoreIndex];
    }

    private void OnDestroy() 
    {
        EventManager.instance.OnPlayerScored -= AddScore;
    }
}
