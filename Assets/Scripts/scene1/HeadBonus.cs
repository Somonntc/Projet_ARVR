using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBonus : MonoBehaviour
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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == Player)
        {
            Debug.Log("Add Heal + 10");
        }
    }

}
