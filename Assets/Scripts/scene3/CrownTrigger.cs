﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownTrigger : MonoBehaviour
{
    private LayerMask Crown;

    private void Awake(){
        Crown = LayerMask.NameToLayer("Crown");
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == Crown){
            Destroy(other.gameObject);
            print("Game ended noice");
        }
    }
}
