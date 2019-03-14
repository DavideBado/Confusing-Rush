using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float Speed = 1, AttackTimer, savedTime = 1.5f, SpeedTimer = 0;
    public GameObject bullet1, bullet2;
    Vector3 CurrentTarget;
    public int i = 0;
    public List<Vector3> targets = new List<Vector3>();
    int BulletType;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTarget = targets[i]; // Ci sono un po' di posti che vorrei visitare, iniziamo dal primo
    }

    // Update is called once per frame
    void Update()
    {
        InUpdate();
    }

    void InUpdate()
    {
        EnemyMove(); // Mi muovo
        Attack(); // Attacco
        UpgradeSpeed(); // Mi do una mossa
    }
    void Attack()
    {
        AttackTimer -= Time.deltaTime; // Aspetto il momento "giusto" per attaccare
        if (AttackTimer <= 0) // È arrivato?
        {
            BulletType = Random.Range(0, 2); // Datemi un proiettile a caso tra quelli che conosco
            if (BulletType == 0) // È di tipo 0?
            {
                Instantiate(bullet1, transform.position, Quaternion.identity); // Lo sparo
            }
            else if (BulletType == 1) // Non era di tipo 0? È forse di tipo 1?
            {
                Instantiate(bullet2, transform.position, Quaternion.identity); // Lo sparo
            }
            AttackTimer = savedTime; // Torno ad aspettare
        }
    }

    void EnemyMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentTarget, Speed * Time.deltaTime); // Vado dove voglio
        if(transform.position == CurrentTarget) // Ci sono arrivato?
        {   if (i == (targets.Count-1)) // Ok, ero arrivato alla fine della lista di destinazioni?
            {
                i = 0; // Torniamo alla prima destinazione
            }
            else i++; // Non ero alla fine? Andiamo alla prossima
            CurrentTarget = targets[i]; // Aggiorno il navigatore
        }
    }

    void UpgradeSpeed() // Ora rompiamo il gioco
    {
        SpeedTimer += Time.deltaTime; // Tengo il tempo
        if(SpeedTimer >= 15) // Sono passati 15 secondi?
        {
            Speed += Speed / 4; // Mi velocizzo
            SpeedTimer = 0; // E torno a contare il tempo
        }
    }
}
