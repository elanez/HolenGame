using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHolen : MonoBehaviour
{
    private Rigidbody _rb;
    public float power = 100f;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate() 
    {
        if(Input.GetMouseButtonDown(0))
            MoveHolen(power);
    }

    public void MoveHolen(float power)
    {
        _rb.AddForce(transform.forward * power, ForceMode.Impulse);
    }
}
