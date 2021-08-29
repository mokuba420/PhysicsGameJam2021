using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAdder : MonoBehaviour
{
    public PhysicMaterial Bounce;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Rocket")
        {
            this.GetComponent<BoxCollider>().material = Bounce;
        }
    }
}
