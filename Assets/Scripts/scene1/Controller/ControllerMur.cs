using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMur : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;
    [SerializeField] private float repeatTime = 5;
    private Vector3 position;
    private bool isToogle = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Deplacement", 0.0f, repeatTime);
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Deplacement()
    {
        isToogle = !isToogle;
        if (isToogle)
            transform.Translate(new Vector3(x, y, z));
        else
            transform.Translate(new Vector3(-x, -y, -z));
    }

}
