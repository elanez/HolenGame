using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holen : MonoBehaviour
{
    private void OnEnable() 
    {
        EventManager.instance.OnPlayerScored += RemoveHolen;
    }

    private void OnDisable()
    {
        EventManager.instance.OnPlayerScored -= RemoveHolen;
    }

    public void RemoveHolen()
    {
        // Debug.Log("Holen out of bounce");
        this.gameObject.SetActive(false);
    }
}
