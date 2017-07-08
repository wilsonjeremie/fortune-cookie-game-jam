using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    Player player;
    public Text distanceText;
    public Image euphoriaBar;
    float distance;

	void Start () {
        distance = 0f;
        player = FindObjectOfType<Player>();
	}
	
	void Update () {
        UpdateDistanceText();
        UpdateEuphoriaBar();
	}

    void UpdateDistanceText()
    {
        distance += player.Speed * Time.deltaTime;
        distanceText.text = "Distance: " + ((int)distance).ToString();
    }

    void UpdateEuphoriaBar()
    {
        float x = player.Euphoria;
        euphoriaBar.transform.localScale = new Vector3(x, 1f, 1f);
    }
}
