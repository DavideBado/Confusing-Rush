using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestMovimento : MonoBehaviour
{
    public Vector3 RMax, LMax, UMax, DMax;
    List<int> validChoices = new List<int>();
    public int Life = 3;
    public int PlayerID = 0;
    public int intUp = 1, intDown = 2, intLeft = 3, intRight = 4;
    bool UpRandom, DownRandom, LeftRandom, RightRandom;

    private void Start()
    {
        RestoreInputList();
    }
    // Update is called once per frame
    void Update()
    {
        InputMove();   
        if(Life <= 0) // Sono un if nel posto sbagliato
        {
            Destroy(gameObject); // E uccido il giocatore quando finisce i punti vita
        }
    }

     public void RandomInput()
     {
        for (int i = 0; i < 4; i++) // Per ognuna delle 4 ditrezioni
        {
            var input = validChoices[Random.Range(0, validChoices.Count)]; // Scelgo un valore random tra 0 e il numero delle scelte disponibili     
            validChoices.Remove(input); // Rimuovo quel valore dalla lista dei scelte disponibili
            Debug.Log("" + input.ToString()); // Un debug non fa mai male...ma troppi rompono il cazzo
            if(UpRandom == false) // Se non ho assegnato un tasto ad up
            {
                intUp = input; // Assegno a lui quello che ho estratto poco fa
                UpRandom = true; // E questo è assegnato
            } else if(DownRandom == false) // Se il si è già stato assegnato, controllo se lo è pure giù
            {
                intDown = input; // Se non era stato assegnato, lo assegno
                DownRandom = true; // Cancello dalla lista di roba da assegnare
            } else if(LeftRandom == false) // Se i precendenti sono già stati assegnati, controllo se sinistra è libero
            {
                intLeft = input; // Nel caso lo assegno
                LeftRandom = true; // Prendo nota di averlo fatto
            } else if(RightRandom == false) // Quelli prima erano già assegnati, rimane solo destra
            {
                intRight = input; // Assegno
                RightRandom = true; // Segno
            }
        }
        RestoreInputList(); // Aggiorno la lista
        RestoreRandomBool(); // Rimetto tutti i dasti come non assegnati
     }
    void InputMove() 
    {
        // Ok, ora si fa chiarezza su come sia possibile che un input sia una variabile int
        
        if (Input.GetAxis("" + intUp.ToString()) > 0 && transform.position.y < UMax.y)
        {
           transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 1, 0), 5f * Time.deltaTime);
        }
        if (Input.GetAxis("" + intDown.ToString()) > 0 && transform.position.y > DMax.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, -1, 0), 5f * Time.deltaTime);
        }
        if (Input.GetAxis("" + intLeft.ToString()) > 0 && transform.position.x > LMax.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(-1, 0, 0), 5f * Time.deltaTime);
        }
        if (Input.GetAxis("" + intRight.ToString()) > 0 && transform.position.x < RMax.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(1, 0, 0), 5f * Time.deltaTime);
        }
    }

    void RestoreInputList()
    {
        validChoices.Add(intUp);
        validChoices.Add(intDown);
        validChoices.Add(intLeft);
        validChoices.Add(intRight);
    }

    void RestoreRandomBool()
    {
        UpRandom = false;
        DownRandom = false;
        LeftRandom = false;
        RightRandom = false;
    }
}
