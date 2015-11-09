using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    public int score = 0;

    public void AddScore(int point)
    {
        if ( point == 1)           
        {
            score++;
            Debug.Log("SCORE;" + score.ToString());
        }

        if (point == 2)           
        {
            score += 3;
            Debug.Log("SCORE;" + score.ToString());
        }
    }

}

/*
    scriptet "SetScore" sitter på alla objekt man kan få poäng för. Deras värde (point) ändras för kategorin objektet tillhör till.
    I detta fall har vanliga poäng värdet (point) 1, Bonus Points = 2, osv. 
    På så sätt kan systemet räkna ut vem som ger poäng, och hur mycket poäng. 
*/
