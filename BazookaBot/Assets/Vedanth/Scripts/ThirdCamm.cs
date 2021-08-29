using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ThirdCamm : MonoBehaviour          // ref = https://www.youtube.com/watch?v=Ta7v27yySKs
{
    public Transform Target, camMove;
    private Camera cam;

    public float Dis = 10f, curX = 0, curY = 0, senX = 4f, senY = 1;
    bool Shoulder;

    private const float YAnglemin = 5, YAngleMax = 50f;

    private void Start()
    {
        Shoulder = false;
        camMove = transform;
        cam = Camera.main;
        if (Target == null) Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -Dis);
        Quaternion rot = Quaternion.Euler(curY, curX, 0);

        if (Target.GetComponent<BallMovement>().Body.Aimming == false)
        {
            camMove.position = Target.position + rot * dir;
            camMove.LookAt(Target.position);
            camMove.SetParent(null);
        }
        else
        {
            if (Target.GetComponent<BallMovement>().Body.Aimming == true)
            {
                camMove.position = Target.GetComponent<BallMovement>().Body.ShoulderPoint.position;
                //camMove.rotation = Target.GetComponent<BallMovement>().Body.ShoulderPoint.rotation;
                //camMove.LookAt(GameObject.FindGameObjectWithTag("LookAt").transform);
                camMove.LookAt(Target.GetComponent<BallMovement>().Body.ShoulderPoint.GetComponent<ShoulderInfo>().ForwaardLook);
                camMove.SetParent(Target.GetComponent<BallMovement>().Body.ShoulderPoint.transform);
                Target.GetComponent<BallMovement>().Body.moveYoBody(camMove.GetComponent<Camera>());

            }
        }
    }

    private void Update()
    {
        ShoulderCheck();

        //Shoulder False
        curX += Input.GetAxis("Mouse X");
        curY += Input.GetAxis("Mouse Y");
        curY = Mathf.Clamp(curY, YAnglemin, YAngleMax);
    }

    void ShoulderCheck()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //Debug.Log("Pressed");
            //  GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.
            //    GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.parent.rotation = GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().PipeRot;
            // GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.rotation = GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().PipeRot;
            //  GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.parent.rotation = new Quaternion(GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.OgRot.x, GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.rotation.y, GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.rotation.z, GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.OgRot.w);
            // GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.parent.rotation = new Quaternion(GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().PipeRot.x, GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.parent.rotation.y, GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.parent.rotation.z, GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().PipeRot.w);
            //  GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.localRotation = GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.OgPos;

           // GameObject.FindGameObjectWithTag("99").SetActive(true);
            
            GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.Half.transform.rotation = GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.OgRot;
            Target.GetComponent<BallMovement>().Body.Aimming = true;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.shoot == true)
                {
                    //Insert some stuff about cool down

                    //Shooty shooty
                    float x = Screen.width / 2;
                    float y = Screen.height / 2;
                    Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
                    GameObject bullet = Instantiate(GameObject.FindGameObjectWithTag("Man").GetComponent<ManagerBoi>().Rocket, Camera.main.transform.position, Camera.main.transform.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ray.direction * 100;

                    //Pushback
                    Vector3 push = -Camera.main.transform.forward * 500f;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().AddForce(push);

                    //Reload
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.shoot = false;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.readloading = GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.ReloadTime;

                    //Dust
                    GameObject dust = Instantiate(GameObject.FindGameObjectWithTag("Man").GetComponent<ManagerBoi>().partiDust, GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.BullShoot.transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.rotation);
                    Destroy(dust, 2);
                }
            }


        }
        else
        {
            //Debug.Log("letgo");
            //  GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.rotation = GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.OgRot;
            //  GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.Half.transform.rotation = GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.OgRot;

            //GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.Half.transform.rotation = GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.OgRot;

            //GameObject.FindGameObjectWithTag("99").SetActive(false);

            Target.GetComponent<BallMovement>().Body.Aimming = false;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.shoot == true)
                {

                    //Shooty shooty
                    GameObject bullet = Instantiate(GameObject.FindGameObjectWithTag("Man").GetComponent<ManagerBoi>().Rocket, GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.BullShoot.transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(1000 * GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.BullShoot.transform.forward);

                    //Pushback
                    Vector3 push = -GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.gameObject.transform.forward * 500f;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().AddForce(push);

                    //Reload
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.shoot = false;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.readloading = GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.ReloadTime;

                    //Dust
                    GameObject dust = Instantiate(GameObject.FindGameObjectWithTag("Man").GetComponent<ManagerBoi>().partiDust, GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.BullShoot.transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.transform.rotation);
                    Destroy(dust, 2);
                }
            }


        }
    }

}
