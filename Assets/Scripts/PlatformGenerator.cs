using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject[] platforms;
    public Transform minHeight;
    public Transform maxHeight;
    float height;
    float timer;
    float minTimer = 0.4f;
    float maxTimer = 0.6f;
    Player player;

    void Start()
    {
        //timer = Random.Range(minTimer, maxTimer);
        timer = 0f;
        //timer = maxTimer;
        player = FindObjectOfType<Player>();
        height = minHeight.position.y;

        StartingPlatforms();
    }

    void Update()
    {
        timer -= Time.deltaTime * player.Speed * (1 / 150f);
        if (timer <= 0)
        {
            timer = Random.Range(minTimer, maxTimer);

            SetHeight();
            Vector3 pos = new Vector3(100f, height, 0f);

            GameObject platform = Instantiate(platforms[Random.Range(0, platforms.Length)], pos, Quaternion.identity) as GameObject;
        }
    }

    void StartingPlatforms()
    {
        for (int i = 0; i < 6; i++)
        {
            SetHeight();
            Vector3 pos = new Vector3(10f + i * 20f, height, 0f);
            GameObject platform = Instantiate(platforms[Random.Range(0, platforms.Length)], pos, Quaternion.identity) as GameObject;
        }
    }

    void SetHeight()
    {
        height += Random.Range(-5f, 5f);
        height = Mathf.Clamp(height, minHeight.position.y, maxHeight.position.y);
    }
}