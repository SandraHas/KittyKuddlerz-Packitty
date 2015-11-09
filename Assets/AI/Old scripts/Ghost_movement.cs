using UnityEngine;
using System.Collections;

public class Ghost_movement : MonoBehaviour {

	public GameObject pacman;
	public GameObject home;

	float speed = 2;
	public float ghostRotation;

	public void GhostRotation (float addRotation){
		ghostRotation = ghostRotation + addRotation;
	}

	void FixedUpdate (){

		//Moves ghost forward
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		gameObject.transform.localRotation = Quaternion.Euler(0, ghostRotation, 0);
	}
}