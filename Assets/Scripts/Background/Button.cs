using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public bool carSelector = false;
    public int car = 0;

    public bool mapSelector = false;
    public int map = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(carSelector)
            FindObjectOfType<Manager>().car = car;
        if (mapSelector)
            FindObjectOfType<Menu>().LoadID(map);
    }

}
