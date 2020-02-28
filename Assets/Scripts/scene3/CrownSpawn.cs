using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownSpawn : MonoBehaviour
{
    [SerializeField] private GameObject crownPrefab = default;
    private GameObject crown;
    [SerializeField] private float timer = 10f;
    // Start is called before the first frame update

    private void Start(){
        StartCoroutine(DoSpawns());
    }
    private IEnumerator DoSpawns() {
        while(true){
            crown = Instantiate(crownPrefab, SpawnRandomPosition(), GetRandomRotation());
            Destroy(crown, 10f);
            yield return new WaitForSeconds(10f);
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
