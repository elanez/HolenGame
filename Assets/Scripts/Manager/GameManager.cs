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
    // [SerializeField]
    // private float _observeDuration = 15f;
    public GameState state;
    public List<Player> playerList = new List<Player>();

    [Header("Holen")]
    public Transform spawnPoint;
    public GameObject holen;
   
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
       SetupGame();
       state = GameState.TURN;
    }

    private void SetupGame()
    {
        state = GameState.START;
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


    
}
