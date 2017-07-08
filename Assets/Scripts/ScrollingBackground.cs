using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.position += (Vector3.left * player.Speed * 0.1f * Time.deltaTime);
        if (transform.position.x < -480)
            transform.position += Vector3.right * 480f;
    }
}