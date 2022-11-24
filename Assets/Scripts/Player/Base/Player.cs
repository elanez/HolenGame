using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Player")]
public class Player : ScriptableObject
{
    public new string name;
    private int _score;
    public int Score
    {
        get => _score;
        set => _score = value;
    }

    private void OnEnable()
    {
        _score = 0;
    }
}
