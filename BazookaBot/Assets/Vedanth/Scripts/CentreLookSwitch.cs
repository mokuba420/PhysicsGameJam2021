using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreLookSwitch : MonoBehaviour
{
    GameObject lookat;

    private void Awake()
    {
        lookat = GameObject.FindGameObjectWithTag("LookAt");
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.Aimming == false)
        {
            lookat.transform.SetParent(null);
            lookat.transform.position = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) - 10, (Screen.height / 2) - 10, Camera.main.farClipPlane));
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.Aimming == true)
            {
                lookat.transform.SetParent(GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.ShoulderPoint.GetComponent<ShoulderInfo>().ForwaardLook);
                lookat.transform.localPosition = new Vector3(0, 0, 0);    //GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.ShoulderPoint.GetComponent<ShoulderInfo>().ForwaardLook.position;
                //lookat.transform.position = GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.ShoulderPoint.GetComponent<ShoulderInfo>().ForwaardLook.position;
                //lookat.transform.position = GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.ShoulderPoint.GetComponent<ShoulderInfo>().ForwaardLook.position;
            }
        }
    }
}
