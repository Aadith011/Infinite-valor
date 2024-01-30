using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSpawner01 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;
    private GameObject spawnedMonster;
    [SerializeField]
    private Transform undeadSpawner01, undeadSpawner02;
    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());   
    }// Start

    // Update is called once per frame
    void Update()
    {
        
    }// Update

    IEnumerator SpawnMonsters(){
        
        while(true){// infinite loop
            yield return new WaitForSeconds(Random.Range(1,5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            
            if(randomSide == 0){//left side
                spawnedMonster.transform.position = undeadSpawner01.position;
                spawnedMonster.GetComponent<Undead01>().speed = Random.Range(4, 10);
            }else{// right side
                spawnedMonster.transform.position = undeadSpawner02.position;
                spawnedMonster.GetComponent<Undead01>().speed = -Random.Range(4, 10); // monster moves from right to left
                spawnedMonster.transform.localScale = new Vector3(-4f, 4f, 4f);
            }
        }// while
    }// SpawnMonsters
}
