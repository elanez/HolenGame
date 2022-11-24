using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHolen : MonoBehaviour
{
    [SerializeField]
    private float _lifetime = 15f;

    void Awake() 
    {
        Destroy(this.gameObject, _lifetime);
    }
}
