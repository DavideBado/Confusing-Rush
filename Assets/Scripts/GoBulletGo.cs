using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBulletGo : MonoBehaviour
{
    public Vector3 Target;
    public int Speed;
    // Update is called once per frame
    void Update()
    {
        InUpdate();
    }

    void InUpdate()
    {
        transform.position += new Vector3(0, -Speed * Time.deltaTime); // Mi muovo verso il basso    
    }

}
