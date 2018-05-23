using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class AIEnemyControl : MonoBehaviour {

	public UnityEngine.AI.NavMeshAgent agent{ get; private set;}
	public float speed;
	GameObject[] targets;
	GameObject target;
	Animator anim;

	// Use this for initialization
	void Start () {
		agent = GetComponentInChildren<NavMeshAgent> ();
		//SearchNearestPlayer ();
		agent.updateRotation = true;
		agent.speed = speed;
		agent.updatePosition = true;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (SearchNearestPlayer ());
		//SearchNearestPlayer ();
		if (target != null)
			agent.SetDestination (target.transform.position);
		if (anim.GetBool ("IsDead"))
			agent.speed = 0;;
	}

	/// <summary>
	/// Mencari player terdekat setiap 3sec agar tidak terlalu memberatkan
	/// </summary>
	/// <returns>The nearest player.</returns>
	IEnumerator SearchNearestPlayer()
	{
		targets = GameObject.FindGameObjectsWithTag ("Player");
		float LeastDistance;

		target = targets [0];
		LeastDistance = Vector3.Distance (transform.position, targets [0].transform.position);
		for (int i = 1; i < targets.Length; i++) {
			if (Vector3.Distance (transform.position, targets [i].transform.position) < LeastDistance)
				target = targets [i];
		}
		yield return new WaitForSeconds (3f);
		StartCoroutine (SearchNearestPlayer ());
	}


}
