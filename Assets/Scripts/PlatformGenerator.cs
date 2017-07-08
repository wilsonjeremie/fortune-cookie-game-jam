using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject[] platforms;
    public Transform minHeight;
    public Transform maxHeight;
    float height;
    float timer;
    float minTimer = 0.9f;
    float maxTimer = 1.2f;
    Player player;

    void Start()
    {
        timer = Random.Range(minTimer, maxTimer);
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

            GameObject tree = Instantiate(platforms[Random.Range(0, platforms.Length)], pos, Quaternion.identity) as GameObject;
        }
    }

    void StartingPlatforms()
    {

    }

    void SetHeight()
    {
        height += Random.Range(-3f, 3f);
        height = Mathf.Clamp(height, minHeight.position.y, maxHeight.position.y);
    }
}