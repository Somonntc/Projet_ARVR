using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    private static LayerMask Player;
    [SerializeField] private GameObject PrefabGhost = default;
    public bool isToggled = true;

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
        if (other.gameObject.layer == Player && isToggled)
        {
            GameObject ghost = Instantiate(PrefabGhost, transform.position, Quaternion.identity,transform);
            ghost.GetComponentInChildren<ghost>().set(other.gameObject, gameObject);
            isToggled = false;
        }
    }

}
