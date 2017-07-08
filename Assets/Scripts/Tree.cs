using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

    Rigidbody rb;
    Player player;

	void Start () {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
        rb.velocity = Vector3.left * player.Speed * 0.1f;
	}
	
	void Update () {
        rb.velocity = Vector3.left * player.Speed * 0.1f;
        if (transform.position.x < -100f)
            Destroy(gameObject);
	}
}