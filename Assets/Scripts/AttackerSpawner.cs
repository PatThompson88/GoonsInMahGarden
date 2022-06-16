using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] List<Attacker> attackerPrefabs;
    [SerializeField] float minSpawnDelay = 3f;
    [SerializeField] float maxSpawnDelay = 6f;
    private bool spawningActive = true;
    private GameSys sys;
    IEnumerator CountdownAndSpawn(){
        yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        var newEnemy = Instantiate(
            attackerPrefabs[0],
            transform.position,
            transform.rotation
        );
    }
    IEnumerator Start(){
        sys = GameObject.Find("GameSys").GetComponent<GameSys>();
        while(spawningActive){
            yield return StartCoroutine(CountdownAndSpawn());
        }
    }
    void Update(){
        
    }
}