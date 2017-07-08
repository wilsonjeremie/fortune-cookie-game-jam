using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomInput {

    public static bool JumpButtonDown()
    {
        return (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.Joystick1Button0));
    }

    public static bool SlowDownButton()
    {
        return (Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.LeftArrow) ||
                Input.GetAxis("Joystick Horizontal") <= -1);
    }

    public static bool SpeedUpButton()
    {
        return (Input.GetKey(KeyCode.D) ||
                Input.GetKey(KeyCode.RightArrow) ||
                Input.GetAxis("Joystick Horizontal") >= 1);
    }
}