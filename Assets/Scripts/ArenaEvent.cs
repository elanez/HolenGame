using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArenaEvent : MonoBehaviour
{
    void OnTriggerExit(Collider col)
    {
        if(!col.CompareTag("Holen"))
            return;
        EventManager.instance.InvokeScore();
        // Debug.Log("Out");
    }
}
