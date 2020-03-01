using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
    }
}
