using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomInput {

    public static bool JumpButtonDown()
    {
        return (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.Joystick1Button0));
    }
}
