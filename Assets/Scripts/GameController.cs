using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Digit[] scoreDigits;
    Player player;
    public Text distanceText;
    float distance;

	void Start () {
        distance = 0f;
        player = FindObjectOfType<Player>();
	}
	
	void Update () {
        UpdateDistance();
	}

    void UpdateDistance()
    {
        distance += player.Speed * Time.deltaTime;

        int distInt = (int)distance;

        scoreDigits[0].Number = (distInt / 100000000);
        scoreDigits[1].Number = (distInt / 10000000) % 10;
        scoreDigits[2].Number = (distInt / 1000000) % 10;
        scoreDigits[3].Number = (distInt / 100000) % 10;
        scoreDigits[4].Number = (distInt / 10000) % 10;
        scoreDigits[5].Number = (distInt / 1000) % 10;
        scoreDigits[6].Number = (distInt / 100) % 10;
        scoreDigits[7].Number = (distInt / 10) % 10;
        scoreDigits[8].Number = (distInt) % 10;
    }
}
