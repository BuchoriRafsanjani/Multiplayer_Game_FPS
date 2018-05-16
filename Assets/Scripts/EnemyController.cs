using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))] 

public class EnemyController : MonoBehaviour {

    public UnityEngine.AI.NavMeshAgent agent { get; private set; }
    public float speed;
    GameObject target; 

	// Use this for initialization
	void Start () {
        agent = GetComponentInChildren<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        agent.updateRotation = true;
        agent.speed = speed;
        agent.updatePosition = true; 

	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
            agent.SetDestination(target.transform.position); 

	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("gameover");
        }
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(this.gameObject);
            Data.score++;

            if (Data.score == 9)
            {
                SceneManager.LoadScene("MainMenu"); // apabila skor mencapai 9 langsung saya setting balik lagi ke Main Menu :D
            }
        }
    }
}
