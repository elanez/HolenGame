using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState{ START, TURN, OBSERVE, END }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Reference")]
    private int _currentRound;
    [SerializeField]
    private int _maxRounds = 15;
    private GameState _state;

    [Header("Holen")]
    public GameObject holen;
    public int totalHolens;
    public Transform spawnPoint;

    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetupEvent();
        _state = GameState.START;
        StartMatch();
    }

    #region game states
    public void StartMatch()
    {
        EventManager.instance.InvokeMatch();
        InstantiateHolens();
        Turn();
    }

    public void Turn()
    {
        if(_state == GameState.START) //first round of the game
        {
            Debug.Log("First Turn");
            _state = GameState.TURN;
            _currentRound = 1;
            UIManager.instance.UpdateRound(_currentRound);
            return;
        }
        _state = GameState.TURN;
        CheckHolenCount();
        if(_state == GameState.END)
            return;
            
        if(!DataManager.instance.NextTurn())
        {
            _currentRound++;
            Debug.Log("GAME: Round: " + _currentRound);
            if(_currentRound > _maxRounds)
            {
                GameEnd();
                return;
            }
        }
        UIManager.instance.UpdateRound(_currentRound);
        EventManager.instance.InvokeTurn();
    }

    private void Observe()
    {
        _state = GameState.OBSERVE;
    }

    private void GameEnd()
    {
        _state = GameState.END;
        EventManager.instance.InvokeGameEnd();
    }

    #endregion

    #region utilities
    public GameState GetState()
    {
        return _state;
    }

    private void InstantiateHolens()
    {
        for(int i = 0; i < totalHolens; i++)
        {
            Vector3 randomPosition = new Vector3(spawnPoint.position.x + Random.Range(-10,10),
                spawnPoint.position.y + 1, spawnPoint.position.z + Random.Range(-10,10));
            Instantiate(holen, randomPosition, Quaternion.identity);
        }
        
    }

    private void ReduceHolen()
    {
        totalHolens--;
        Debug.Log("GAME: Holens left: " + totalHolens);
    }

    private void CheckHolenCount()
    {
        if (totalHolens <= 0)
            GameEnd();
    }

    private void SetupEvent() 
    {
        // EventManager.instance.OnStartTurn += Turn;
        EventManager.instance.OnGameObserve += Observe;
        EventManager.instance.OnPlayerScored += ReduceHolen;
    }
    #endregion

}
