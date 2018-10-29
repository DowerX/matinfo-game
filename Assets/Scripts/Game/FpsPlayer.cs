using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsPlayer : MonoBehaviour {

    public float speed = 1;
    public float lookspeed = 1;
    //public bool keyboard = true;
    public Transform cam;

	void Update () {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(0, 0, speed * Time.deltaTime * Input.GetAxis("Vertical"));
        }

        cam.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * lookspeed);
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * lookspeed);

        //if (Input.GetKeyDown("end"))
        //{
        //    if(Cursor.lockState == CursorLockMode.None)
        //    {
        //        Cursor.lockState = CursorLockMode.Locked;
        //        Cursor.visible = false;
        //    }

        //    if (Cursor.lockState == CursorLockMode.Locked)
        //    {
        //        Cursor.lockState = CursorLockMode.None;
        //        Cursor.visible = true;
        //    }
        //}
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
