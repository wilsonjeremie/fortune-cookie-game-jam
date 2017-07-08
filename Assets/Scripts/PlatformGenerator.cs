using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject[] platforms;
    float timer;
    //float minTimer = 0.2f;
    float maxTimer = 1.2f;
    Player player;

    void Start()
    {
        //timer = Random.Range(minTimer, maxTimer);
        timer = maxTimer;
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        timer -= Time.deltaTime * player.Speed * (1 / 150f);
        if (timer <= 0)
        {
            timer = maxTimer;

            Vector3 pos = new Vector3(100f, 10f, 0f);

            GameObject tree = Instantiate(platforms[Random.Range(0, platforms.Length)], pos, Quaternion.identity) as GameObject;
        }
    }
}