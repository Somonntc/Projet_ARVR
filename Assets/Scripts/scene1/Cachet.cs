using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cachet : MonoBehaviour
{
    // Start is called before the first frame update
    private static LayerMask Player;

    void Awake()
    {
        Player = LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Player)
        {
            other.gameObject.GetComponent<ControllerPlayer>().invisible = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Player)
        {
            other.gameObject.GetComponent<ControllerPlayer>().invisible = true;
        }
    }

}
