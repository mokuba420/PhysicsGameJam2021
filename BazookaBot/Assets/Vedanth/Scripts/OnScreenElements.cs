using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenElements : MonoBehaviour
{
    public GameObject snake;    // props if you get the reference...

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>().Body.Aimming == true)
        {
            snake.gameObject.SetActive(true);
        }
        else
        {
            snake.gameObject.SetActive(false);
        }
    }

}
