using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamm : MonoBehaviour          // ref = https://www.youtube.com/watch?v=Ta7v27yySKs
{
    public Transform Target, camMove;
    private Camera cam;

    public float Dis = 10f, curX = 0, curY = 0, senX = 4f, senY = 1;

    private const float YAnglemin = 5, YAngleMax = 50f;

    private void Start()
    {
        camMove = transform;
        cam = Camera.main;
        if (Target == null) Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -Dis);
        Quaternion rot = Quaternion.Euler(curY, curX, 0);
        camMove.position = Target.position + rot * dir;
        camMove.LookAt(Target.position);
    }

    private void Update()
    {
        curX += Input.GetAxis("Mouse X");
        curY += Input.GetAxis("Mouse Y");
        curY = Mathf.Clamp(curY, YAnglemin, YAngleMax);
    }
}
