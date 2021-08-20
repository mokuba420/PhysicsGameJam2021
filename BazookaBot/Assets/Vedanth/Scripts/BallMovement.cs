using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public BodyInfo Body;
    public float Speed, maxspeed = 25f;
    Rigidbody rigi;
    Quaternion PipeRot;
    public float turnspeed = 100f;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody>();
        PipeRot = Body.transform.parent.rotation;
    }

    private void Update()                           // REMEMBER TO ADD:        /Body turns with the camera  /add force forward based on camera view     /weapon fire and recoil     /polish movement and add extra speed
    {
        Rotation();
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
        rigi.AddForce(mov * Speed);                 // maybe add a position.forward add force?
    }


    private void LateUpdate()
    {
        MoveBall();
        PreventRotationOfBody();
    }

    void PreventRotationOfBody()
    {
        // Body.transform.parent.rotation = Quaternion.Euler(0, 0, this.transform.rotation.x * -1);
        Body.transform.parent.rotation = new Quaternion(PipeRot.x, PipeRot.y, Body.transform.parent.rotation.z, PipeRot.w);    //PipeRot;
    }

    void Rotation()
    {
        float Turning = Input.GetAxis("Horizontal") * (turnspeed * Time.deltaTime);
        transform.Rotate(0, 0, Turning);
       // Body.transform.parent.Rotate(0, Turning, 0);
    }
}
