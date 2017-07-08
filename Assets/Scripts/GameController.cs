using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    Player player;
    public Text distanceText;
    float distance;

	void Start () {
        distance = 0f;
        player = FindObjectOfType<Player>();
	}
	
	void Update () {
        distance += player.Speed * Time.deltaTime;
        distanceText.text = "Distance: " + ((int)distance).ToString();
	}
}
