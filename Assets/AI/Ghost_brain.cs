using UnityEngine;
using System.Collections;

public class Ghost_brain : MonoBehaviour {

	Ghost_eyes eyes;

	float goLeft;
	float goRight;
	float goForward;
	float goBack;

	bool openLeft;
	bool openForward;
	bool openRight;

	//To give true 1 and false 0
	int _openLeft;
	int _openForward;
	int _openRight;

	int openPaths;

	bool exhaust = true;

	float timer;
	float startTimer = 0.2f;

	public Ghost_movement ghostAddRotation;
	

	void Start () {
		eyes = GetComponent<Ghost_eyes>();
		ghostAddRotation = GetComponent<Ghost_movement>();

		goLeft = -90f;
		goRight = 90f;
		goForward = 0f;
		goBack = 180f;

	}

	void Update () {

		timer = timer + 1f * Time.deltaTime;
		if(timer > startTimer){
			timer = 0f;
			exhaust = false;
			startTimer = 0f;
		}


		openLeft = eyes.openLeft;
		openForward = eyes.openForward;
		openRight = eyes.openRight;

		openPaths = _openLeft + _openForward + _openRight;

		if(openLeft) _openLeft = 1;
		else _openLeft = 0;
		if(openForward) _openForward = 1;
		else _openForward = 0;
		if(openRight) _openRight = 1;
		else _openRight = 0;

		int nr = Random.Range (0, openPaths);

		if(!exhaust){
			exhaust = true;

			if(openPaths == 1){
				if(openLeft) ghostAddRotation.GhostRotation (goLeft);
				if(openForward) ghostAddRotation.GhostRotation (goForward);
				if(openRight) ghostAddRotation.GhostRotation (goRight);
				startTimer = 0.6f;
			}
			if(openPaths > 1) {
				//Debug.Log (nr);
				if(openLeft && nr == 0) ghostAddRotation.GhostRotation (goLeft);
				if(openForward && nr == 2) ghostAddRotation.GhostRotation (goForward);
				if(openRight && nr == 1) ghostAddRotation.GhostRotation (goRight);
				startTimer = 0.6f;
			}
			if (openPaths < 1){
				ghostAddRotation.GhostRotation (goBack);
				startTimer = 0.1f;
			}
		}


//	public Vector3 GhostRotation(bool left, bool forward, bool right) {
//
//		Vector3 rotation = transform.forward;
//		int amount = 0;
//
//		if(left) amount++;
//		if(forward) amount++;
//		if(right) amount++;
//
////		Random nr = new Random ();
//		int nr = Random.Range (0, amount);
//		if (nr == 0){rotation = -transform.right;}
//		if (nr == 1){rotation = transform.forward;}
//		if (nr == 2){rotation = transform.right;}
//		
//		return rotation;
//		Debug.Log (rotation);
	}
}