using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public new Transform camera;
    public Transform launchPoint;
    public GameObject interactableHolen;

    [Header("Throwing")]
    // public KeyCode throwKey;
    public float throwForce;
    public Renderer holenHold;
    
    private void Start()
    {
        EventManager.instance.OnStartTurn += ShowHolenHold;
    }
    private void Update()
    {
        if(GameManager.instance.GetState() != GameState.TURN)
            return;
        
        if(Input.GetMouseButtonDown(0))
            Throw();
    }

    private void Throw()
    {
        holenHold.enabled = false;
        GameObject projectile = Instantiate(interactableHolen, launchPoint.position, camera.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceDirection = camera.transform.forward;
        RaycastHit hit;
        
        if(Physics.Raycast(camera.position, camera.forward, out hit, 500f))
        {
            forceDirection = (hit.point - launchPoint.position).normalized;
        }

        projectileRb.AddForce(forceDirection * throwForce, ForceMode.Impulse);

        EventManager.instance.InvokeObserve();
    }

    private void ShowHolenHold()
    {
        holenHold.enabled = true;
    }
    
}
