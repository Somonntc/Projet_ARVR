using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{
    [SerializeField] private GameObject GoldenKey = default;
    [SerializeField] private GameObject DummyKey = default;
    [SerializeField] private float timer = 10f;
    private Material rend;
    private GameObject goldenKey;
    private GameObject dummyKey;
    private Color randomColor;
    public static bool spawn;
    
    private void Awake(){
        rend = GetComponent<Renderer>().material;
        spawn = true;
    }

    private void Start(){
        StartCoroutine(DoSpawns());
    }
    public IEnumerator DoSpawns() {
        while(spawn){
            //Golden Key spawn
            goldenKey = Instantiate(GoldenKey, new Vector3(10, 8, 10), GetRandomRotation());
            Destroy(goldenKey, 10f);
            //Other key spawn
            for(int i = 0; i<=3; i++){
                dummyKey = Instantiate(DummyKey, new Vector3(12, 8, 12), GetRandomRotation());
                Destroy(dummyKey, 10f);
                randomColor = Random.ColorHSV(0f, 1f);
                //Change color of each dummy key
                foreach(Renderer childRenderer in dummyKey.GetComponentsInChildren<Renderer>()){
                    childRenderer.material.color = randomColor;
                }
            }
            yield return new WaitForSeconds(15f);
        }
    }

    private Vector3 SpawnRandomPosition(){
        return new Vector3(
            Random.Range(-61f, 134f),
            11,
            Random.Range(-41f, 53f)
        );
    }

    private static Quaternion GetRandomRotation() {
            return Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
    }
    
}
