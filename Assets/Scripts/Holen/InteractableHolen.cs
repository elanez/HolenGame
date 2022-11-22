using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHolen : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MoveHolen(float power)
    {
        rb.AddForce(transform.forward * power);
    }
}
