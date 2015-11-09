using UnityEngine;
using System.Collections;

public class SphereMovem : MonoBehaviour 
{
    //variabler för spelarens rörelser
	public int speed = 10;
    public Rigidbody sphere;

    //variabler för Respawn
    public GameObject spawnPoint;

    public int healthPoints = 5;
    bool isDead;
    bool eaten;
  //-----
    void Start () 
	{
		sphere = GetComponent<Rigidbody>();
    }


    void Update ()
	{
		//Anger input för rörelsensriktning.
		float moveV = Input.GetAxis ("Vertical");
		moveV *= speed;
		//Förflyttning.
		sphere.MovePosition (sphere.position + (transform.forward * moveV) *  Time.deltaTime);

		//Anger input för rörelsens riktning.
		float moveH = Input.GetAxis ("Horizontal");
        moveH *= speed;
        //Förflyttning.
        sphere.MovePosition (sphere.position + (transform.right * moveH) * Time.deltaTime);

        //------------------ Live Mechanincs

        if (isDead)
        {
            Application.LoadLevel(Application.loadedLevel);             // Startar om leveln. 
        }

        if (eaten)                                                    //Se "Notes" längst ned på koden.
        {
            PlaceBackPacis();                                           // 2
            Debug.Log("PlaceBackPacis()");
            eaten = false;
        }
    }

    void PlaceBackPacis()                                               // 1
    {
        StartCoroutine(WaitReset());
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        transform.position = spawnPoint.transform.position;
        Debug.Log("Pos Changed");
        
    }

    IEnumerator WaitReset()
    {
        yield return new WaitForSeconds(1.0f);                         // 3
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        StopCoroutine(WaitReset());
        Debug.Log("StopCor.");
    }

    //------------------- Lives Counter

    void OnCollisionEnter(Collision collider)                          //Om spelaren kolliderar med Spöket (gameObject.tag = "Respawn")...
    {
        if (collider.gameObject.tag == "Respawn")
        {
            eaten = true;                                            //så byter värdet av "eaten" variabeln till "true"..
            healthPoints -= 1;                                      //Pacman förlorar ett liv.
            if (healthPoints == 0)
            {
                isDead = true;                                   
            }
        }
    }
}


//-------------------------------------------
/*

MovePosition(rigidbody.position of rb + (Transform.red axis in global space * horizontal movement) *in secs).


void ControllerColliderHit()
    {
        if (gameObject.tag == "Respawn")
        {
            eaten = true;
            healthPoints -= 1;
            Debug.Log("hP -1");

        }
    }
*/
/*
När "eaten" får värdet "true", så utförs 3 metoder i en specifik ordning, i domino-effekt (mer eller mindre).
1) "PlaceBackPacis()"- metoden körs.
Inom PlaceBackPacis () sker följande: först körs en Coroutine. Sedan stängs Pacmans mesh av. Pacman återgår till sin SpawnPoint (Empty GameObject)
Sen hamnar vi på Update () --> if (eaten), igen. och eaten får värdet false (efter att ha kört PBP().
Vid det här laget börjar Coroutinen att köras, och den gör följande: 1. Väntar 1 sekund, sätter på meshen i Pacman sedan avslutar den Coroutinen. 
*/