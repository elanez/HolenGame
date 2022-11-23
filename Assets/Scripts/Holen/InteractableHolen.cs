using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHolen : MonoBehaviour
{
    [SerializeField]
    private float _lifetime = 2f;

    void Awake() 
    {
        Destroy(this, _lifetime);
    }
}
