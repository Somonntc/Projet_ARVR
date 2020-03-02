using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cachet : MonoBehaviour
{
    // Start is called before the first frame update
    private static LayerMask Player;
    [SerializeField] private TextMeshProUGUI invisible;

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
            invisible.SetText("Invisible !!");
            other.gameObject.GetComponent<ControllerPlayer>().invisible = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Player)
        {
            invisible.SetText(string.Empty);
            other.gameObject.GetComponent<ControllerPlayer>().invisible = true;
        }
    }

}
