using UnityEngine;
using System.Collections;

public class Teleporty : MonoBehaviour {

	public GameObject otherPortal;
	public float turnSpeed;
	
	void OnTriggerEnter(Collider objects){
		Debug.Log ("its colliding with the portal");
		if(objects.tag == "Player" || objects.tag == "Enemy")
			objects.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 2;
	}
}