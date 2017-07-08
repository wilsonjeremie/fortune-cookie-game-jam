using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour {

    public bool touchingGround;

    void Start()
    {
        touchingGround = false;
    }

    void OnTriggerStay(Collider col)
    {
        //if (col.gameObject.tag == "Ground")
        //{
            touchingGround = true;
        //}
    }

    void OnTriggerExit(Collider col)
    {
        //if (col.gameObject.tag == "Ground")
        //{
            touchingGround = false;
        //}
    }
}
