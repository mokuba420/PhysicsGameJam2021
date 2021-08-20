using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyInfo : MonoBehaviour
{
    public Animator Ani;

    private void Awake()
    {
        Ani = this.GetComponent<Animator>();
        this.transform.rotation = new Quaternion(0, 0, 0, this.transform.localRotation.w);
    }

    private void Update()
    {
        
    }
}
