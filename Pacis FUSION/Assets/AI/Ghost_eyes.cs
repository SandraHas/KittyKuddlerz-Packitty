using UnityEngine;
using System.Collections;

public class Ghost_eyes : MonoBehaviour {

	//Booleans to check if the paths are open or closed.
	public bool openLeft;
	public bool openRight;
	public bool openForward;
	float forwardLenght = 1f;	//How far the ghost can see

	void FixedUpdate (){
		RaycastHit hit;
		Ray forwardRay = new Ray (transform.position, transform.forward);
		Ray leftRay = new Ray (transform.position, -transform.right);
		Ray rightRay = new Ray (transform.position, transform.right);
		
		
		if (Physics.Raycast (leftRay, out hit, forwardLenght)){
			openLeft = false;
		} else {
			openLeft = true;
			Debug.DrawRay (transform.position, -transform.right * forwardLenght);
		}
		if (Physics.Raycast (rightRay, out hit, forwardLenght)){
			openRight = false;
		} else {
			openRight = true;
			Debug.DrawRay (transform.position, transform.right * forwardLenght);
		}
		if (Physics.Raycast (forwardRay, out hit, forwardLenght)){
			openForward = false;
		} else {
			openForward = true;
			Debug.DrawRay (transform.position, transform.forward * forwardLenght);
		}
	}
}