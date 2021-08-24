using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class BodyInfo : MonoBehaviour
{
    public Animator Ani;
    public float Angle = 180;
    public Transform ShoulderPoint;
    public bool Aimming = false;
    public GameObject LeftArm, RightArm, Ant;
    public BallMovement Ball;
   public  Vector3 OgPos;
   public  Quaternion OgRot;
    public GameObject Half;
    float curY;

    private void Awake()
    {
        Ani = this.GetComponent<Animator>();
        this.transform.rotation = new Quaternion(0, 0, 0, this.transform.localRotation.w);
        OgPos = this.transform.position;
        //OgPos = this.transform.localPosition;
        OgRot = this.transform.rotation;
        //OgRot = this.transform.localRotation;
    }

    private void Update()
    {
        if(Aimming == false)
        {
            //this.transform.position = OgPos;
            //this.transform.localPosition = OgPos;
            //this.transform.rotation = OgRot;
            this.transform.localRotation = OgRot;
        }
    }

    public void moveYoBody(Camera boi)   //come on everybody!
    {
       //curY = Mathf.Clamp(curY + Input.GetAxis("Mouse Y"), -10, 10);
      //  transform.Rotate(0, (Input.GetAxis("Mouse X") * Angle * Time.deltaTime), (Input.GetAxis("Mouse Y") * Angle * Time.deltaTime), Space.World);
       // transform.Rotate(0, (Input.GetAxis("Mouse X") * Angle * Time.deltaTime), (curY * Angle * Time.deltaTime), Space.World);
        transform.Rotate(0, (Input.GetAxis("Mouse X") * Angle * Time.deltaTime),0, Space.World);
        //transform.parent.Rotate((Input.GetAxis("Mouse X") * Angle * Time.deltaTime), (Input.GetAxis("Mouse Y") * Angle * Time.deltaTime), 0, Space.World);
    }
}
