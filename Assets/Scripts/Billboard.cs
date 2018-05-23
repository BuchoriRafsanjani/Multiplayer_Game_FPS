using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	public Camera followCam;

	void Start()
	{
		
	}

	void Update () {
		transform.LookAt(Camera.main.transform);
	}
}