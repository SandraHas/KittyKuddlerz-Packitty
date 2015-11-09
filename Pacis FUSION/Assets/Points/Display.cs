using UnityEngine;
using System.Collections;
using UnityEngine.UI;                                       //En klass för all UI (y).

public class Display : MonoBehaviour
{
    float timer;

    public Text displayTime;
    public Text displayScore;
    public Text displayLives;

    //varibel för att kalla på en annan klass (den som håller koll på poäng-räkningen & Pacman's liv).
    public Score scoreSet;
    public SphereMovem pacis;
	
	void Update ()
    { 
        timer += Time.deltaTime;
        int time = System.Convert.ToInt32(timer);
        displayTime.text = "Time: " + time.ToString() + "s.";

        displayScore.text = "Score: " + scoreSet.score.ToString();

        displayLives.text = "Lives: " + pacis.healthPoints.ToString();
	}


}

//----------------------------------------
/*
Toggle cameras:
    public Camera cameraM;
    public Camera map;
    Start()
       cameraM.enabled = true;
       map.enabled = false;
    Update()
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cameraM.enabled = !cameraM.enabled;
            map.enabled = !map.enabled;
        }
*/