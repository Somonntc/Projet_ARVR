using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Sensitivity = 3f;
    [SerializeField] private Transform cameraTransform = default;
    [SerializeField] private float speed = 0.2f;
    private Transform playerTransform;
    private Rigidbody rb;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = GetComponent<Transform>();        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandleMovement();
        HandleCameraMovement();
        if(transform.position.y <= 0){
            transform.position = new Vector3(-5, 3.4f, 0f);
        }
    }

    private void HandleMovement(){
        Vector3 currentPosition = playerTransform.position;
        Vector3 deltaPosition = (
            playerTransform.right * Input.GetAxis("Horizontal")
            + playerTransform.forward * Input.GetAxis("Vertical")
            ) * speed;
        deltaPosition.y = 0f;
        playerTransform.position = currentPosition + deltaPosition;
        rb.MovePosition(currentPosition + deltaPosition);
    }

    private void HandleCameraMovement() {
        float yawn = Input.GetAxis("Mouse X") * Sensitivity;
        float pitch = -Input.GetAxis("Mouse Y") * Sensitivity;
        pitch = Mathf.Clamp(pitch,-70f, 70f);
        playerTransform.Rotate(Vector3.up * yawn);
        cameraTransform.Rotate(Vector3.right * pitch);
    }
}
