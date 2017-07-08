using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour {
    public GameObject crystal;
    Rigidbody rb;
    Player player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
        rb.velocity = Vector3.left * player.Speed * 0.1f;

        if (Random.Range(0, 4) != 0)
        {
            Destroy(crystal);
        }
    }

    void Update()
    {
        //rb.velocity = Vector3.left * player.Speed * 0.1f;
        transform.position += (Vector3.left * player.Speed * 0.1f * Time.deltaTime);
        if (transform.position.x < -100f)
            Destroy(gameObject);
    }
}
