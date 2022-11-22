using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArenaTrigger : MonoBehaviour
{
    public UnityEvent TriggerExit;

    
    void OnTriggerExit(Collider col)
    {
        if(!col.CompareTag("Holen"))
            return;

        TriggerExit.Invoke();
        Debug.Log("Out");
    }
}
