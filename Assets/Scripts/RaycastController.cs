using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    private int layerMask;
    // Start is called before the first frame update
    void Awake()
    {
        layerMask = LayerMask.GetMask("Window", "Tableau", "Book", "Crown", "GoldenKey", "DummyKey", "Furniture");
    }

    // Update is called once per frame
    void Update()
    {
        DisplayRaycastHit();
    }

    void DisplayRaycastHit(){
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * Mathf.Infinity);
        if(Physics.Raycast (transform.position, transform.forward, out hit, Mathf.Infinity, layerMask)) {
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
             if (hit.transform.gameObject.layer == LayerMask.NameToLayer("GoldenKey")) {
                 //Debug.Log("Golden Key you have to take it");
                 //Possibility to take the key by pressing LeftShift (to change ?) (in case it is above something or unreachable)
                 if(Input.GetKeyDown(KeyCode.LeftShift)){
                     GoldenKeyTrigger.KeyTakken();
                     Destroy(hit.transform.gameObject);
                 }
             }
             if (hit.transform.gameObject.layer == LayerMask.NameToLayer("DummyKey")) {
                 //Debug.Log("Just a random key I don't need it");
             }
             if(Input.GetKeyDown(KeyCode.R)){
                 print("Distance to the object : "+ hit.distance);
             }
         }
    }
}
