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
            goldenKey = Instantiate(GoldenKey, SpawnRandomPosition(), GetRandomRotation());
            Destroy(goldenKey, 100f);
            //Other key spawn
            for(int i = 0; i<=3; i++){
                dummyKey = Instantiate(DummyKey, SpawnRandomPosition(), GetRandomRotation());
                Destroy(dummyKey, 100f);
                randomColor = Random.ColorHSV(0f, 1f);
                //Change color of each dummy key
                foreach(Renderer childRenderer in dummyKey.GetComponentsInChildren<Renderer>()){
                    childRenderer.material.color = randomColor;
                }
            }
            yield return new WaitForSeconds(150f);
        }
    }

    private Vector3 SpawnRandomPosition(){
        return new Vector3(
            Random.Range(-98f, 98),
            8,
            Random.Range(-57f, 72f)
        );
    }

    private static Quaternion GetRandomRotation() {
            return Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
    }
    
}
