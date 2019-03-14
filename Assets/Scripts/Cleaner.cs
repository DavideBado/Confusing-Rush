using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // Qualcuno o qualcosa è entrato in contatto con te?
    {
        Destroy(other.gameObject); // Uccidilo
    }
}
