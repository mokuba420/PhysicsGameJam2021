using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPlate : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Can").GetComponent<GlobalCanvans>().Anim.SetBool("Load", false);
        GameObject.FindGameObjectWithTag("Ball").transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z);
    }
}
