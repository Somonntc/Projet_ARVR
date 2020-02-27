using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    private int layerMask;
    // Start is called before the first frame update
    void Awake()
    {
        layerMask = LayerMask.GetMask("Window", "Tableau", "Book", "Crown");
    }

    // Update is called once per frame
    void Update()
    {
        DisplayRaycastHit();
    }

    void DisplayRaycastHit(){
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 20);
        if(Physics.Raycast (transform.position, transform.forward, out hit, 20, layerMask)) {
             if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Window")) {
                 Debug.Log("It's a window");
             }
             if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Tableau")) {
                 Debug.Log("It's a frame of a duck");
             }
             if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Book")) {
                 Debug.Log("It's some book");
             }
             if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Crown")) {
                 Debug.Log("This is the crown you have to find to win !");
             }
         }
    }
}
