using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArenaEventHandler : MonoBehaviour
{
    void OnTriggerExit(Collider col)
    {
        if(!col.CompareTag("Holen"))
            return;
        
        Destroy(col.gameObject);
        EventManager.instance.InvokeScore();
    }
}
