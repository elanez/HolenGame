using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamController : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orientation;

    float xRotation;
    float yRotation;
    
    private void Start() 
    {
        SetupEvent();
        ActivateController();
    }

    private void ActivateController() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void DeactivateController()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update() 
    {
        if(GameManager.instance.GetState() == GameState.END)
            return;
        
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -10f, 45f);
        yRotation = Mathf.Clamp(yRotation, -45f, 45f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void SetupEvent()
    {
        // EventManager.instance.OnStartTurn += ActivateController;
        // EventManager.instance.OnGameObserve += DeactivateController;
        EventManager.instance.OnGameEnd += DeactivateController;
    }
}
