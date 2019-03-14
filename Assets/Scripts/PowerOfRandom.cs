using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOfRandom : MonoBehaviour // Io faccio bestemmiare
{
    private void OnTriggerEnter(Collider other) // Ho scontrato qualcosa?
    {
        if(other.GetComponent<TestMovimento>() != null) // È il giocatore?
        {
            other.GetComponent<TestMovimento>().RandomInput(); // Ok, rendiamogli questo gioco ancora meno giocabile
            Destroy(gameObject); // Ora posso morire
        }
    }
}
