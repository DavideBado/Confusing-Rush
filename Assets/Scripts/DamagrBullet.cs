using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagrBullet : MonoBehaviour // Ciao, io faccio male
{
    private void OnTriggerEnter(Collider other) // Ho sontrato qualcosa?
    {
        if(other.GetComponent<TestMovimento>() != null) // È il giocatore?
        {
            other.GetComponent<TestMovimento>().Life--; // Tolgo vita al giocatore anche se richiamare una funzione sarebbe meglio
            Destroy(gameObject); // Ho fatto ciò che dovevo, ora posso morire
        }
    }
}
