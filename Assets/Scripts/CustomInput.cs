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
        return (Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.LeftArrow));
    }

    public static bool SpeedUpButton()
    {
        return (Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.RightArrow));
    }
}