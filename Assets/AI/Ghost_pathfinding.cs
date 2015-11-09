using UnityEngine;
using System.Collections;

public class Ghost_pathfinding : MonoBehaviour {

	public float speed;
	public Transform goal;
	NavMeshAgent ghost;


	void Start () {
		ghost = GetComponent<NavMeshAgent>();
		ghost.speed = speed;
	}
	
	void FixedUpdate () {
		ghost.destination = goal.position;
	}
}