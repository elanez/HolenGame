using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState{ START, TURN, OBSERVE, END }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Reference")]
    // private int _currentRound;
    // [SerializeField]
    // private int _maxRounds = 15;
    // [SerializeField]
    // private float _turnDuration = 15f;
    [SerializeField]
    private float _observeDuration = 15f;
    private GameState _state;

    [Header("Holen")]
    public Transform spawnPoint;
    public GameObject holen;
    [Header("Players")]
    public List<Player> playerList = new List<Player>();
   
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
       SetupGame();
       EventManager.instance.OnPlayerObserve += SwitchToObserveMode;
       _state = GameState.TURN;
    }

    private void Update() 
    {
        if(_state == GameState.OBSERVE)
        {
            StartCoroutine(ObserveRoutine());
        }
    }

    private void SetupGame()
    {
        _state = GameState.START;
        // _currentRound = 0;

        for(int i=0; i<playerList.Count; i++)
        {
            if(i == 0)
                playerList[i].IsTurn = true;
            else
                playerList[i].IsTurn = false;

            playerList[i].Score = 0;
        }

        Instantiate(holen, spawnPoint.position, spawnPoint.rotation);
    }

    public void SwitchToObserveMode()
    {
        _state = GameState.OBSERVE;
    }

    public GameState getState()
    {
        return _state;
    }

    #region Routine
    IEnumerator ObserveRoutine()
    {
        yield return new WaitForSeconds(_observeDuration);
        _state = GameState.TURN;
    }
    #endregion
    
}
