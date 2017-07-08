using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour {
    public GameObject[] trees;
    public Transform nearRange;
    public Transform farRange;
    float timer;
    float minTimer = 0.2f;
    float maxTimer = 0.4f;
    Player player;

	void Start () {
        timer = Random.Range(minTimer, maxTimer);
        player = FindObjectOfType<Player>();
	}
	
	void Update () {
        timer -= Time.deltaTime * player.Speed * (1 / 150f);
        if (timer <= 0)
        {
            timer = Random.Range(minTimer, maxTimer);
            float x = Mathf.Lerp(nearRange.position.x, farRange.position.x, Random.Range(0f, 1f));
            float z = Mathf.Lerp(nearRange.position.z, farRange.position.z, Random.Range(0f, 1f));

            Vector3 pos = new Vector3(x, nearRange.position.y, z);
            Quaternion rot = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            GameObject tree = Instantiate(trees[Random.Range(0,2)], pos, rot) as GameObject;
        }
	}
}
