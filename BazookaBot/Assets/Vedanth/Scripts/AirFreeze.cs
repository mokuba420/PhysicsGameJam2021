using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFreeze : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Rocket")
        
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        
    }
}
