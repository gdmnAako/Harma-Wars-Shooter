using System;
using UnityEngine;
using Cinemachine; 

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")] 
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public CameraStyle currentcamera;
    public Transform CombatLook;
    public enum CameraStyle
    {
        Basic,
        Combat
    }

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    private void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        if (currentcamera == CameraStyle.Basic)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
        }
        
        else if (currentcamera == CameraStyle.Combat)
        {
            Vector3 dirToCombat = CombatLook.position - new Vector3(transform.position.x, CombatLook.position.y, transform.position.z);
            orientation.forward = dirToCombat.normalized;

            playerObj.forward = dirToCombat.normalized; 
        }
    }
}
