using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digit : MonoBehaviour {

    public int Number
    { 
        set
        {
            digit = value;
            SetActiveDigit(value);
        }
        get {return digit; }
    }
    public GameObject[] digits;
    GameObject activeDigit;
    int digit;

    void Start()
    {
        InitializeDigits();
    }

    void InitializeDigits()
    {
        foreach (GameObject obj in digits)
        {
            obj.SetActive(false);
        }
        activeDigit = digits[0];
        activeDigit.SetActive(true);
    }

    void SetActiveDigit(int index)
    {
        activeDigit.SetActive(false);
        activeDigit = digits[index];
        activeDigit.SetActive(true);
    }
}