using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody header = default;
    [SerializeField] private Rigidbody body = default;
    [SerializeField] private float mouseSensitivity = 1f;
    [SerializeField] private float speed = 1f;
    private LayerMask Pancarte = default;
    private float yawn = 0.0f;
    private float pitch = 0.0f;
    public bool invisible = true;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Pancarte = LayerMask.NameToLayer("Pancarte");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Movement();
        CameraMovement();
        ClickRight();
    }

    private void Movement()
    {
        Vector3 currentPosition = body.transform.position;
        Vector3 deltaPosition = (
           body.transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed
            + body.transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed
        );
        body.MovePosition(currentPosition + deltaPosition);
    }

    private void ClickRight()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Vector3 fwd = header.transform.TransformDirection(Vector3.forward);
            Vector3 pst = header.transform.position + fwd * 1f;
            RaycastHit hit;
            if (Physics.Raycast(pst, fwd,out hit, 10)) {
                if (hit.transform.gameObject.layer == Pancarte) {
                    Pancarte pancarte = hit.transform.gameObject.GetComponentInParent<Pancarte>();
                    pancarte.go();
                }
            }
        }
    }

    private void CameraMovement()
    {
        yawn += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        body.MoveRotation(Quaternion.Euler(new Vector3(0, yawn, 0f)));
        header.MoveRotation(Quaternion.Euler(new Vector3(pitch, yawn, 0f)));
    }

}
