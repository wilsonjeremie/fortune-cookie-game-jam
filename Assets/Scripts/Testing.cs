using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {
    float rot;
    float dRot = 128f;
    Quaternion startRot;
	void Start () {
        startRot = transform.rotation;
        rot = 0f;
	}
	
	void Update () {
        rot += Time.deltaTime * dRot;
        transform.rotation = startRot * Quaternion.Euler(rot, rot, rot);
	}
}
