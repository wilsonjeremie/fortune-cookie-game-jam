using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVertical : MonoBehaviour {

    public Transform follow;
    Vector3 startPos;

	void Start () {
        startPos = transform.position;
	}
	
	void Update () {
        float distance = follow.position.y - startPos.y;
        transform.position = startPos + Vector3.up * distance * 0.4f;
	}
}
