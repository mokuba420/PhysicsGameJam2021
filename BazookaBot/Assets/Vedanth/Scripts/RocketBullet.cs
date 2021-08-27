using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject poff = GameObject.FindGameObjectWithTag("Man").GetComponent<ManagerBoi>().partiExplosion;
        ContactPoint contect = collision.contacts[0];
        GameObject boi = Instantiate(poff, contect.point, new Quaternion());
        boi.transform.position = new Vector3(boi.transform.position.x, boi.transform.position.y + 3.5f, boi.transform.position.z);
        //float rnd = Random.Range(0.05f, 0.3f);
        //boi.transform.localScale = new Vector3(rnd, rnd, rnd);
        Destroy(boi, 2);
        Destroy(this.gameObject, 0.25f);
    }
}
