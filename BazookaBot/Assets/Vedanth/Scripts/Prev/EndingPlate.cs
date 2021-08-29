using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPlate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
         //   Debug.Log("YOU WIN!!!");
            //Insert Win Function.... Yeah, later...
           
        
             GameObject.FindGameObjectWithTag("Can").GetComponent<GlobalCanvans>().FinishedMission();

        }
    }
}
