using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoldenKeyTrigger : MonoBehaviour
{
    public static int GoldenkeyCounter;
    private LayerMask GoldenKey;
    private LayerMask NextLevel;
    // Start is called before the first frame update
    private void Awake()
    {
        GoldenKey = LayerMask.NameToLayer("GoldenKey");
        NextLevel = LayerMask.NameToLayer("NextLevel");
        GoldenkeyCounter = 0;
    }

    private void Update(){
        CheckNumberOfKey();
    }

    //Check the actual number of key
    private void CheckNumberOfKey(){
        if(GoldenkeyCounter == 5){
            KeySpawn.spawn = false;
        }
    }

    private void OnTriggerEnter(Collider other){
        //Collision with golden key
        if(other.gameObject.layer == GoldenKey){
            KeyTakken();
            Destroy(other.gameObject);
        }
        ///Collision for the next level need to add && GoldenKeyCounter == 5 condition
        if(other.gameObject.layer == NextLevel){
            print("Load the other scene");
            SceneManager.LoadScene("Scene3");
        }
    }

    public static void KeyTakken(){
        GoldenkeyCounter += 1;
        print("GoldenKey taken, current number of key : " + GoldenkeyCounter);
    }

    
}
