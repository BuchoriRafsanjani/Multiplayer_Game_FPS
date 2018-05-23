using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowParticle : MonoBehaviour {
	public GameObject particle;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Destroy")) {
			Destroy (gameObject);
			GameObject p = GameObject.Instantiate (particle,transform.position,particle.transform.rotation);
			Destroy (p,1);
		}

	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag.Equals("Bullet")){        
			anim.SetBool ("IsDead",true);
		}

		if(col.gameObject.tag.Equals("Player")&& !anim.GetBool("IsDead")){    
			var hit = col.gameObject;
			var health = hit.GetComponent<Health> ();
			if (health != null) {
				health.TakeDamage (10);
			}
			anim.SetBool ("IsDead",true);
		}
	}
}
