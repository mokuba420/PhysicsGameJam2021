using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public BodyInfo Body;
    public float Speed, maxspeed = 25f, JUmpHeight = 15f;
    Rigidbody rigi;
    public Quaternion PipeRot;
    public float turnspeed = 100f;
    bool Grounded;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody>();
     //   Debug.Log("Start " + Body.transform.parent.rotation.y);
        PipeRot = Body.transform.rotation;   
        Body.Ball = this;
    }

    private void Update()                           // REMEMBER TO ADD:        /Body turns with the camera  /add force forward based on camera view     /weapon fire and recoil     /polish movement and add extra speed
    {
     //   Rotation();
        Brake();

        if (Input.GetKeyDown(KeyCode.Space))
        {
           if(Grounded == true) JumpForce();
        }
    }

    //So you're a fan of 
    void JumpForce() //?    WHY?
    {
        Grounded = false;
        rigi.constraints = RigidbodyConstraints.None;
        rigi.AddForce(0, JUmpHeight * 10, 0);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rigi.constraints = RigidbodyConstraints.None;
            Grounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            marioPuff();
            rigi.constraints = RigidbodyConstraints.FreezePositionY;
            Grounded = true;
        }
        else
        {
            SparkThatfly(collision.contacts[0].point);
        }


    }

    void marioPuff()
    {
        GameObject poff = GameObject.FindGameObjectWithTag("Man").GetComponent<ManagerBoi>().partiPuff;
        GameObject boi = Instantiate(poff, Body.Centre.transform.position, new Quaternion());
        boi.transform.position = new Vector3(boi.transform.position.x, boi.transform.position.y - 0.5f, boi.transform.position.z);
        boi.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        Destroy(boi, 2);
    }

    void SparkThatfly(Vector3 contact)
    {
        GameObject poff = GameObject.FindGameObjectWithTag("Man").GetComponent<ManagerBoi>().partiSpark;
        GameObject boi = Instantiate(poff, contact, new Quaternion());
        boi.transform.position = new Vector3(boi.transform.position.x, boi.transform.position.y, boi.transform.position.z);
        float rnd = Random.Range(0.05f, 0.3f);
        boi.transform.localScale = new Vector3(rnd, rnd, rnd);
        Destroy(boi, 0.25f);
    }

    //      Add Jump        / Fix camera issue      / add rotation

    void Brake()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            rigi.velocity = new Vector3(0, 0, 0);
        }
    }

    void MoveBall()
    {
       // float Hori = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");

        Vector2 Movement = new Vector2(rigi.velocity.x, rigi.velocity.z);

        if(Movement.magnitude > maxspeed)
        {
            Movement = Movement.normalized * maxspeed;
            rigi.velocity = new Vector3(Movement.y, rigi.velocity.y, Movement.x);
        }

        Vector3 mov = new Vector3(0, Vert, 0);
        mov = transform.TransformDirection(mov);
        Vector3 fir = this.transform.forward;
       // Vector3 dir = fir * Camera.main.transform.rotation;
        rigi.AddForce(mov * Speed);                 // maybe add a position.forward add force?
    }

    void ForceBall()
    {
        float Vert = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(0, Speed * Vert, 0);
        dir.Normalize();  //  Debug.Log(Vert);
      //  Vector3 dir = this.transform.position.normalized;
      //  Vector3 dir = this.transform.position.normalized;
        //rigi.AddForce(dir * (Speed * Vert) * Time.deltaTime);
        rigi.AddRelativeForce(dir * (Speed * -Vert));
         //rigi.AddRelativeForce(Vector3.up * (Vert * Speed) * Time.deltaTime);
         //rigi.AddRelativeForce(Vector3.up * (Vert * Speed) * Time.deltaTime);
    }

    //forward and back
    void CamForce()
    {
        float Vert = Input.GetAxis("Vertical");
        //Vector3 dir = new Vector3(0, Speed * Vert, 0);
        Vector3 dir = Camera.main.transform.forward * Vert;
      //  dir.Normalize();
       // Vector3 camm = dir * Camera.main.transform.forward.x;
        //rigi.AddRelativeForce(camm);
     
        if(dir.magnitude > maxspeed)
        {
            dir = dir.normalized * maxspeed;
        }

        rigi.AddForce(dir);
    }

    //left and right
    void ballCamforce()
    {
        float Turning = Input.GetAxis("Horizontal");
        Vector3 dir = Camera.main.transform.right * Turning;
        
        if (dir.magnitude > (maxspeed* 1/2) )
        {
            dir = dir.normalized * (maxspeed * 1/2);
        }

        rigi.AddForce(dir);
    }

    private void LateUpdate()
    {
        //MoveBall();
        //  ForceBall();
        CamForce();
        ballCamforce();
     //   PreventRotationOfBody();
    }

    void PreventRotationOfBody()
    {
        // Body.transform.parent.rotation = Quaternion.Euler(0, 0, this.transform.rotation.x * -1);
        if (Body.Aimming == true)
        {
               Body.transform.parent.rotation = PipeRot;
            Body.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
            Body.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
            Body.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        }   
        //  Body.transform.parent.rotation = new Quaternion(PipeRot.x, PipeRot.y, Body.transform.parent.rotation.z, PipeRot.w);    //PipeRot;   
        else
        {
            //Body.transform.parent.rotation = new Quaternion(PipeRot.x, Body.transform.parent.rotation.y, Body.transform.parent.rotation.z, PipeRot.w);    //PipeRot;   
            Body.transform.rotation = new Quaternion(Body.OgRot.x, Body.transform.rotation.y, Body.transform.rotation.z, Body.OgRot.w);    //PipeRot;   
            //Body.transform.rotation = new Quaternion(PipeRot.x, Body.transform.parent.rotation.y, Body.transform.parent.rotation.z, PipeRot.w);    //PipeRot;   
            Body.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }   //  Debug.Log(PipeRot.y);   Debug.Log(Body.transform.parent.localRotation.y + " + " + Body.transform.parent.rotation.y);
       // Body.transform.parent.rotation = new Quaternion(PipeRot.x, (this.transform.rotation.y - Body.Angle ), Body.transform.parent.rotation.z, PipeRot.w);    //PipeRot;
    }

    void Rotation()
    {
        float Turning = Input.GetAxis("Horizontal") * (turnspeed * Time.deltaTime);
        transform.Rotate(0, 0, Turning);
       // Body.transform.parent.Rotate(0, Turning, 0);
    }
}
