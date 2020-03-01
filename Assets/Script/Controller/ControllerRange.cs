using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRange : MonoBehaviour
{
    private static LayerMask Player;
    [SerializeField] private GameObject body = default;

    // Start is called before the first frame update
    void Awake()
    {
        Player = LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Player)
        {
            body.GetComponent<ghost>().isToggled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Player)
        {
            body.GetComponent<ghost>().isToggled = false;
        }
    }

}
