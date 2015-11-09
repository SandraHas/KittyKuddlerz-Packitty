using UnityEngine;
using System.Collections;

public class SetScore : MonoBehaviour
{
    public int scorePoint = 1;
    public Score score;

    void OnTriggerEnter (Collider point)                //Skickar information om collision till klassen "Score". (dvs. +poäng)
    {
        score.AddScore(scorePoint);
    }
	
    void Update ()
    {
        transform.Rotate(new Vector3(30, 45, 60) * Time.deltaTime);
    }
}

/*
   Denna script (klass) sitter på alla collectibles. 
   Se "Score" för mer info.
*/
