using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MonsterSpawner : NetworkBehaviour {
	public GameObject monster;
	public bool isMonsterSpawned = false;

	// Use this for initialization
	void Start(){
		//StartCoroutine (StartSpawning ());
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMonsterSpawned) {
			if (NetworkServer.connections.Count == 2) {
				if(!isServer){return;}
				Debug.Log ("Start Spawning Monters");
				StartCoroutine (StartSpawning ());
				isMonsterSpawned = true;
			}
		}
	}

	IEnumerator StartSpawning() {
		yield return new WaitForSeconds (Random.Range(5f, 7f));
		GameObject _monster=Instantiate (monster, transform.position, Quaternion.identity);  
		NetworkServer.Spawn(_monster);
		StartCoroutine (StartSpawning ());
	}
}
