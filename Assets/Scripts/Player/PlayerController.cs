using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public new Transform camera;
    public Transform attackPoint;
    public GameObject interactableHolen;

    [Header("Throwing")]
    // public KeyCode throwKey;
    public float throwForce;


    private void Update()
    {
        if(GameManager.instance.state != GameState.TURN)
            return;
        
        if(Input.GetMouseButtonDown(0))
            Throw();
    }

    private void Throw()
    {
        GameObject projectile = Instantiate(interactableHolen, attackPoint.position, camera.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceDirection = camera.transform.forward;
        RaycastHit hit;
        
        if(Physics.Raycast(camera.position, camera.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        projectileRb.AddForce(forceDirection * throwForce, ForceMode.Impulse);
    }
    
}
