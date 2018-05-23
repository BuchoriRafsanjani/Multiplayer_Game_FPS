using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public float speed=3f;
	public GameObject ball;
	public GameObject titikLontar;
	public float powerLontar;
	public Camera cam;
	AudioSource audio;
	public AudioClip Throw;

	// Use this for initialization
	void Start () {
		if(!isLocalPlayer)
		{
			cam.enabled = false;
		}
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;
		cam.enabled = true;
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
		{
			return;
		}

		transform.Translate (0, 0, Input.GetAxis ("Vertical") * speed * Time.deltaTime);
		transform.Rotate (0, Input.GetAxis ("Horizontal") * 60 * Time.deltaTime, 0);

		if (Input.GetKeyDown (KeyCode.Space)) {
			audio.PlayOneShot (Throw);
			CmdFire ();
		}
	}

	[Command]
	void CmdFire()
	{
		
		GameObject _ball = GameObject.Instantiate (ball, titikLontar.transform.position, titikLontar.transform.rotation);
		_ball.GetComponent<Rigidbody>().velocity = _ball.transform.forward * powerLontar;
		NetworkServer.Spawn (_ball);
		GameObject.Destroy (_ball, 5f);
	}

}
