using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

    float minScale = 2f;
    float maxScale = 4f;
    Rigidbody rb;
    Player player;

	void Start () {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
        transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
        rb.velocity = Vector3.left * player.Speed * 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = Vector3.left * player.Speed * 0.1f;
        if (transform.position.x < -100f)
            Destroy(gameObject);
	}
}
