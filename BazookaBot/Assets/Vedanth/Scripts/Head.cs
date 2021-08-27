using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject poff = GameObject.FindGameObjectWithTag("Man").GetComponent<ManagerBoi>().partiSpark;
        ContactPoint contect = collision.contacts[0];
        GameObject boi = Instantiate(poff, contect.point, new Quaternion());
        boi.transform.position = new Vector3(boi.transform.position.x, boi.transform.position.y, boi.transform.position.z);
        float rnd = Random.Range(0.05f, 0.3f);
        boi.transform.localScale = new Vector3(rnd, rnd, rnd);
        Destroy(boi, 2);
       // Debug.Log("spark");
    }
}
