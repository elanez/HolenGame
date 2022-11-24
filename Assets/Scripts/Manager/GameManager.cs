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
    [SerializeField]
    private float _turnDuration = 15f;
    [SerializeField]
    private float _observeDuration = 15f;
    private GameState _state;

    [Header("Holen")]
    public GameObject holen;
    public float totalHolens;
    public Transform spawnPoint;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartGame();
        SetupEvents();
        _state = GameState.TURN;
    }

    #region game states
    private void StartGame()
    {
        Debug.Log("Start Game");
        _currentRound = 1;
        _state = GameState.START;
        DataManager.instance.SetupPlayers();
        Instantiate(holen, spawnPoint.position, spawnPoint.rotation);
    }

    private void Turn()
    {
        if(!DataManager.instance.NextTurn())
        {
            _currentRound++;
            Debug.Log("Round: " + _currentRound);
            if(_currentRound > _maxRounds)
            {
                GameEnd();
                return;
            }
        }
        _state = GameState.TURN;
        Debug.Log("GameState: Turn");
    }

    private void Observe()
    {
        _state = GameState.OBSERVE;
        StartCoroutine(ObserveRoutine());
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

    public void ReduceHolen()
    {
        totalHolens--;
        Debug.Log("Holens left: " + totalHolens);
        if(totalHolens >= 0)
            GameEnd();
    }

    private void SetupEvents() 
    {
        EventManager.instance.OnPlayerScored += ReduceHolen;
        EventManager.instance.OnGameObserve += Observe;
    }

    private void OnDestroy()
    {
        EventManager.instance.OnPlayerScored -= ReduceHolen;
        EventManager.instance.OnGameObserve -= Observe;
    }
    #endregion

    #region Routine
    IEnumerator ObserveRoutine()
    {
        yield return new WaitForSeconds(_observeDuration);
        if(_state == GameState.OBSERVE)
            Turn();
    }
    #endregion

}
