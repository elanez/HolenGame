using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public List<Player> playerList = new List<Player>();

    private int _activePlayerIndex;

    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        SetupEvent();
    }

    private void SetupPlayers()
    {
        _activePlayerIndex = 0;
    }

    private void AddScore()
    {
        Debug.Log("DATA: " + playerList[_activePlayerIndex].name + " has scored!");
        playerList[_activePlayerIndex].Score++;
        Debug.Log("DATA: " + playerList[_activePlayerIndex].name + " score: " 
            + playerList[_activePlayerIndex].Score);
        UIManager.instance.UpdateScore();
    }

    public Player GetActivePlayer()
    {
        return playerList[_activePlayerIndex];
    }

    public bool NextTurn()
    {
        if(_activePlayerIndex+1 < playerList.Count)
        {
            Debug.Log("DATA: Update to next player");
            _activePlayerIndex++;
            return true;
        }
        else
        {
            Debug.Log("DATA: Restart player");
            _activePlayerIndex = 0;
            return false;
        }
            
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
        {
            Debug.Log("DATA: Tie Game");
            return null;
        }
            
        else
        {
            Debug.Log("DATA: WINNER: " + playerList[highScoreIndex].name);
            return playerList[highScoreIndex];
        }
    }

    private void SetupEvent()
    {
        EventManager.instance.OnStartMatch += SetupPlayers;
        EventManager.instance.OnPlayerScored += AddScore;
    }
}
