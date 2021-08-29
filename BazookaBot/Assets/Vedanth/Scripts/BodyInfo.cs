using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;


public class BodyInfo : MonoBehaviour
{
    public Animator Ani;
    public float Angle = 180;
    public Transform ShoulderPoint;
    public bool Aimming = false;
    public GameObject LeftArm, RightArm, Ant;
    public BallMovement Ball;
   public  Quaternion OgPos;
   public  Quaternion OgRot;
    public GameObject Half;
    float curY;
    public GameObject Centre;
    public float ReloadTime = 2;
    public bool shoot = true;
    public float readloading;
    public GameObject BullShoot;

    private void Awake()
    {
        Ani = this.GetComponent<Animator>();
        this.transform.rotation = new Quaternion(0, 0, 0, this.transform.localRotation.w);
        //OgPos = this.transform.position;
        //OgPos = this.transform.localPosition;
        //OgRot = this.transform.rotation;
        //OgRot = this.transform.localRotation;
        OgRot = Half.transform.rotation;
       // OgPos = this.transform.rotation;
        OgPos = this.transform.localRotation;
    }

    private void Update()
    {
        if(Aimming == false)
        {
            //this.transform.position = OgPos;
            //this.transform.localPosition = OgPos;
            //this.transform.rotation = OgRot;
          //  this.transform.localRotation = OgRot;
        }

        if(readloading > 0 && shoot == false)
        {
            readloading -= Time.smoothDeltaTime;

            GameObject.FindGameObjectWithTag("Reload").GetComponent<Image>().fillAmount = (readloading / ReloadTime) * 1;


            if (readloading <= 0)
            {
                shoot = true;
                GameObject.FindGameObjectWithTag("Reload").GetComponent<Image>().fillAmount = 1;
            }
        }

    }

    public void moveYoBody(Camera boi)   //come on everybody!
    {
         curY = Mathf.Clamp(curY + Input.GetAxis("Mouse Y") , -30, 30);
      //  transform.Rotate(0, (Input.GetAxis("Mouse X") * Angle * Time.deltaTime), (Input.GetAxis("Mouse Y") * Angle * Time.deltaTime), Space.World);
       // transform.Rotate(0, (Input.GetAxis("Mouse X") * Angle * Time.deltaTime), (curY * Angle * Time.deltaTime), Space.World);
        
        //X axis only
        transform.Rotate(0, (Input.GetAxis("Mouse X") * (Angle) * Time.deltaTime),0, Space.World);
        
       //  boi.transform.Rotate(curY * (Angle * (1/3)), 0,0, Space.World);
         boi.transform.Rotate(curY , 0,0, Space.World);
        
        
        //transform.parent.Rotate((Input.GetAxis("Mouse X") * Angle * Time.deltaTime), (Input.GetAxis("Mouse Y") * Angle * Time.deltaTime), 0, Space.World);
    }
}
