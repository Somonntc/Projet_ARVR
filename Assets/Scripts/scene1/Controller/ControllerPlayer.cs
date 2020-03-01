using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    private LayerMask Pancarte = default;
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

    }
}
