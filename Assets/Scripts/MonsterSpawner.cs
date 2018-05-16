using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {

    public GameObject monster;
    private int enemyCount = 0;

    // Use this for initialization
    void Start () {
        StartCoroutine(StartSpawning()); 
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(5f, 7f));
        Instantiate(monster, transform.position, Quaternion.identity);
        enemyCount++;
        print(enemyCount);
        StartCoroutine(StartSpawning());

        if(enemyCount == 3)
        {
            StopAllCoroutines(); // Membatasi Enemy muncul hanya 3 saja disetiap GameObjek spawner, karena ada 3 spawner maka jumlah enemynya 9 sebagai batasnya
        }
    }

}
