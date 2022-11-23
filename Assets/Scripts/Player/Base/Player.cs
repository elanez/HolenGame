using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Player")]
public class Player : ScriptableObject
{
    public new string name;
    private bool _isTurn;
    private int _score;
    private Vector3 _position;

    public bool IsTurn
    {
        get => _isTurn;
        set => _isTurn = value;
    }

    public int Score
    {
        get => _score;
        set => _score = value;
    }

    public Vector3 Position
    {
        get => _position;
        set => _position = value;
    }
}
